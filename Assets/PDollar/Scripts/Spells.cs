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
	public Text score;

//SteamVR Input Actions
	public SteamVR_Action_Single squeeze;
	public SteamVR_Action_Boolean grabPinch;
	private float triggerValue;
	public SteamVR_Input_Sources handType;

	public GameObject projectile;

	private bool isDrawing  = false;
	
	private Camera cam; 
	void Start () {

		cam = GameObject.Find("Camera").GetComponent<Camera>();
		
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
		Debug.Log(transform.forward);
		//Gets the trigger value ranged between 0.0 and 1.0
		triggerValue = squeeze.GetAxis(handType);

		//Convert the 3D position to 2D poition
		virtualKeyPosition = cam.WorldToScreenPoint (transform.position);

		//Checks if we have pressed the Space key (Testing) or the trigger (HTC Vive users)
		if (Input.GetKeyDown (KeyCode.Space) || grabPinch.GetStateDown(handType)) {
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
		if (Input.GetKey (KeyCode.Space) || triggerValue > 0.0f) {
			//Add the position to the pointcloud array
			points.Add (new Point (virtualKeyPosition.x, -virtualKeyPosition.y, strokeId));

			//We are drawing a spell
			isDrawing = true;
			Debug.Log ("Drawing");
		}
		
		//We have released trigger but there is available a drawing
		if(triggerValue == 0.0f && isDrawing == true) {
			isDrawing = false;
			PredictGesture ();
		}
	}


	public void PredictGesture () {

		recognized = true;

		Gesture candidate = new Gesture (points.ToArray ());
		Result gestureResult = PointCloudRecognizer.Classify (candidate, trainingSet.ToArray ());

		message = gestureResult.GestureClass + " " + gestureResult.Score;
		Debug.Log (message);

		score.text = gestureResult.GestureClass + " mastery " + (int)(gestureResult.Score*100);

		fire();
	}

	private void fire(){
		GameObject fireball = Instantiate(projectile,transform.position,transform.rotation);
           
		Rigidbody rb = fireball.GetComponent<Rigidbody>();
		
		rb.velocity = transform.forward * 20;

		Debug.Log("Fire" + transform.position);
	}
}