using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class DragonController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] targets;
    private int currentTarget = 0;
    public int lives;
    public int speed;
    public GameObject endgame;
    public SteamVR_Action_Vibration hapticAction;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, targets[currentTarget].position, step);
        Vector3 targetDir = targets[currentTarget].position - transform.position;
        Vector3 newDir = Vector3.RotateTowards(transform.forward, targetDir, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);

        if (Vector3.Distance(transform.position,  targets[currentTarget].position) < 2.0f){
            currentTarget = (currentTarget + 1) % targets.Length;
            Debug.Log("Current target: " + currentTarget);
        }
        
    }

    void OnTriggerEnter(Collider obj) {

        Debug.Log("Enemy collided: " + obj.gameObject.name);
        
        if(obj.gameObject.tag == "FivePointStar" || obj.gameObject.tag == "P") {

            lives--;

            AudioSource audio = GetComponent<AudioSource>();
            audio.Play();
            hapticAction.Execute(0,1,150,1,SteamVR_Input_Sources.Any);
            
            if(lives<=0) {
                Debug.Log("End Game");
                GameObject[] gameObjects =  GameObject.FindGameObjectsWithTag ("Enemy");
        
                // No sería más facil "Destroy(this)"?
                for(int i = 0 ; i < gameObjects.Length ; i ++)
                    Destroy(gameObjects[i]);
                
                Destroy(gameObject);
                endgame.SetActive(true);
            }
            
        }
       
    }
}
