using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class CoinManager : MonoBehaviour
{
    private Rigidbody rb;

        private SteamVR_Input_Sources handType = SteamVR_Input_Sources.RightHand;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown("space") || SteamVR_Actions._default.GrabPinch.GetStateDown(handType))
        {
            //thrown = true;
            Debug.Log("space key was pressed");
            rb.velocity = new Vector3(rb.velocity.x * 10, 0, rb.velocity.z * 10);
        }
    }

    public void EnableGravity(){
        Debug.Log("Holi");
        rb.isKinematic = false;
        rb.useGravity = true;
    }


}
