using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordController : MonoBehaviour
{

    int counter = 0;

    public GameObject otherSword;

    private void Update() {
      
        transform.position = otherSword.transform.position;
        transform.rotation = otherSword.transform.rotation;
    }
    void OnTriggerEnter(Collider obj) {

        if(obj.name=="troll_body_low") {
         
            Debug.Log("Dead trolls: " + TrollController.deathEnemies);

        }
        
    
    }


}
