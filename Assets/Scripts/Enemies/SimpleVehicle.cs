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
    public GameObject player;

    public SteamVR_Action_Vector2 touchpadAction;

    float x,y;


    void Start ()
    {
        myTransform = GetComponent<Transform>();
        myRB = GetComponent<Rigidbody>();
   }
	
	void Update ()
    {
         if (touchpadAction.GetActive(SteamVR_Input_Sources.LeftHand)) {
            x = touchpadAction.GetAxis(SteamVR_Input_Sources.LeftHand)[0];
            y = touchpadAction.GetAxis(SteamVR_Input_Sources.LeftHand)[1];
         }

        // else {
        //     x = Input.GetAxis("Horizontal");
        //     y = Input.GetAxis("Vertical");
        // }
        
    
        currentMoveSpeed = moveSpeed * y;
        currentTurnSpeed = turnSpeed * x;
        
        if(Mathf.Abs(y) > 0.5){
            myRB.velocity = player.transform.forward * moveSpeed * y;
        }
    

        //myRB.velocity = myTransform.forward * currentMoveSpeed;
        //myRB.angularVelocity = turnVector * currentTurnSpeed;

        // this.transform.rotation = player.transform.rotation;
        // player.transform.rotation = this.transform.rotation;

        joyStickRotation.x = currentMoveSpeed;
        joyStickRotation.y = -currentTurnSpeed * 10;
        joyStickRotation.z = -currentTurnSpeed * 10;
    }
}
