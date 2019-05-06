using UnityEngine;
using System.Collections;
using Valve.VR;

public class SimpleVehicle : MonoBehaviour {

    public float moveSpeed= 6;
    public float turnSpeed= 0.5f;

    public Vector3 turnVector = new Vector3(0,1,0);

    private float currentMoveSpeed;
    private float currentTurnSpeed;

    private Transform myTransform;
    private Rigidbody myRB;

    private Vector3 joyStickRotation;

    public SteamVR_Action_Vector2 touchpadAction;

    float x,y;


    void Start ()
    {
        myTransform = GetComponent<Transform>();
        myRB = GetComponent<Rigidbody>();
   }
	
	void FixedUpdate ()
    {
        x = touchpadAction.GetAxis(SteamVR_Input_Sources.LeftHand)[0];
        y = touchpadAction.GetAxis(SteamVR_Input_Sources.LeftHand)[1];
        
        //For keyboard
        //currentMoveSpeed = moveSpeed * Input.GetAxis("Vertical");
        //currentTurnSpeed = turnSpeed * Input.GetAxis("Horizontal");
        
        //For touchpad
    
        currentMoveSpeed = moveSpeed * y;
        currentTurnSpeed = turnSpeed * x;
    

        myRB.velocity = myTransform.forward * currentMoveSpeed;
        myRB.angularVelocity = turnVector * currentTurnSpeed;

        joyStickRotation.x = currentMoveSpeed;
        joyStickRotation.y = -currentTurnSpeed * 10;
        joyStickRotation.z = -currentTurnSpeed * 10;
    }
}
