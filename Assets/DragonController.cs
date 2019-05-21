using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    // Start is called before the first frame update

    public int lives = 3;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider obj) {

        Debug.Log("Enemy collided: " + obj.gameObject.name);
        
        if(obj.gameObject.tag == "FivePointStar" || obj.gameObject.tag == "P") {

            lives--; 
            
            if(lives<=0) {
                Debug.Log("End Game");
            }
            
        }
       
    }
}
