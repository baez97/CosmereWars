using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityController : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject gameobject;
  
    public void activateGravity(GameObject gameobject) {
        rb = gameobject.GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    public void detach(string name){
        if (name == "Elantris"){
            WorldController.droppedElantris = true;
        }

        if (name == "Roshar"){
            WorldController.droppedRoshar = true;

        }

        if (name == "Scadrial"){
            WorldController.droppedScadrial = true;

        }


    }
}
