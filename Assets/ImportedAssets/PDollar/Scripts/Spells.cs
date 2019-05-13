using System;
using System.Collections.Generic;
using System.IO;
using PDollarGestureRecognizer;
using UnityEngine;
using Valve.VR;
using UnityEngine.UI;

public class Spells : MonoBehaviour {

	private List<Gesture> trainingSet = new List<Gesture> ();

	private List<Point> points = new List<Point> ();
	private int strokeId = -1;

	private Vector3 virtualKeyPosition = Vector2.zero;
	private string message;
	private bool recognized;

	//UI Element
	//public Text score;

	//SteamVR Input Actions
	public SteamVR_Action_Boolean grabPinch;
	public SteamVR_Input_Sources handType;
    public GameObject vrCamera;
	public GameObject[] projectiles;
	private bool isDrawing  = false;
	public GameObject tracked_Obj;

	private Camera cam;

	public static bool enableP = false;
	public static bool enable5Start = false;
	
	void Start () {

		cam = Camera.main;

		//Load pre-made gestures
		TextAsset[] gesturesXml = Resources.LoadAll<TextAsset> ("GestureSet/10-stylus-MEDIUM/");
		foreach (TextAsset gestureXml in gesturesXml)
			trainingSet.Add (GestureIO.ReadGestureFromXML (gestureXml.text));

		//Load user custom gestures
		string[] filePaths = Directory.GetFiles (Application.persistentDataPath, "*.xml");
		foreach (string filePath in filePaths)
			trainingSet.Add (GestureIO.ReadGestureFromFile (filePath));

	}

	void Update () {
	
		//Convert the 3D position to 2D poition
		virtualKeyPosition = tracked_Obj.transform.position;

		//Checks if we have pressed the Space key (Testing) or the trigger (HTC Vive users)

		if (grabPinch.GetStateDown(handType)) {
			Debug.Log ("Evento raro");

			//Checks if we have already recognize the gesture to clean the pointcloud
			if (recognized) {
				recognized = false;
				strokeId = -1;
				points.Clear ();
			}

			++strokeId;
		}

		//Checks if we are holding the Space key (Testing) or the trigger (HTC Vive users)
		if (grabPinch.GetState(handType)) {
			//Add the position to the pointcloud array
			points.Add (new Point (virtualKeyPosition.x, -virtualKeyPosition.y, strokeId));

			//We are drawing a spell
			isDrawing = true;
			Debug.Log ("Drawing");

		}
		
		//We have released trigger but there is available a drawing
		
		if(!grabPinch.GetState(handType) && isDrawing) {
			isDrawing = false;
			PredictGesture ();
			points.Clear ();
		}
         
	}


	public void PredictGesture () {

		recognized = true;

		Gesture candidate = new Gesture (points.ToArray ());
		Result gestureResult = PointCloudRecognizer.Classify (candidate, trainingSet.ToArray ());

		message = gestureResult.GestureClass + " " + gestureResult.Score;
		Debug.Log (message);

        //score.text = gestureResult.GestureClass + " mastery " + (int)(gestureResult.Score*100);

        string gestureString = gestureResult.GestureClass;
        if ( gestureResult.Score > 0.6f )
        {
            if ( string.Equals(gestureString, "five point star") && enable5Start )
            {
		        fire(projectiles[0]);
            }
            else if ( string.Equals(gestureString, "P") && enableP)
            {
                fire(projectiles[1]);
            } 
        }
	}

	private void fire(GameObject projectile){
        Debug.Log(vrCamera.transform.position);
        Debug.Log(vrCamera.transform.rotation);
		GameObject fireball = Instantiate(projectile,vrCamera.transform.position,vrCamera.transform.rotation);
           
		Rigidbody rb = fireball.GetComponent<Rigidbody>();
		
		rb.velocity = vrCamera.transform.forward * 20;
	}
}