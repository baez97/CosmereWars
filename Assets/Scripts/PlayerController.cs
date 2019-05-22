using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;


public class PlayerController : MonoBehaviour
{
    public int lives = 5;
    public GameObject room;
    public SteamVR_Action_Vibration hapticAction;
    private float timeout = 5;
    private bool hit = false;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Player Controller running");
    }

    // Update is called once per frame
    void Update()
    {
        if (hit){
            timeout -= Time.deltaTime;
            if (timeout < 0){
                hit = false;
            }
        }
    }

    void OnCollisionEnter (Collision col)
    {
        Debug.Log("Collision" + col.gameObject.name);
        if(col.gameObject.tag == "Weapon" && !hit)
        {
            hit = true;
            lives--;
            Debug.Log("You've been hit: Lives " + lives);
            hapticAction.Execute(0,1,150,1,SteamVR_Input_Sources.Any);
            if(lives <=0) {
                Scene scene = SceneManager.GetActiveScene();
                Destroy(room);
                SceneManager.LoadScene(scene.name);
            }
        }
        
    }
}
