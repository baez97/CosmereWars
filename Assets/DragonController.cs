using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] targets;
    public int lives;
    public int speed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //float step =  speed * Time.deltaTime; // calculate distance to move
        //transform.position = Vector3.MoveTowards(transform.position, target.position, step);
        
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
