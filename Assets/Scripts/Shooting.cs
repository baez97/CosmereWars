using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;


public class Shooting : MonoBehaviour
{
    public GameObject projectile;


    public SteamVR_Action_Single squeezeAction;


    // Update is called once per frame
    void Update()
    {
        float triggerValue = squeezeAction.GetAxis(SteamVR_Input_Sources.RightHand);

        if (Input.GetKeyDown(KeyCode.Space) || triggerValue > 0.0f) {
            GameObject fireball = Instantiate(projectile);
            //fireball.transform.position = new Vector3(-1.46f,1.4f,-9.74f);
            fireball.transform.position  = transform.position;
            Rigidbody rb = fireball.GetComponent<Rigidbody>();
            rb.velocity = transform.forward * 20;
            Debug.Log("Fire" + transform.position);
        }
    }
}
