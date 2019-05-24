using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;

public class VampireBehaviour : MonoBehaviour
{
    public GameObject AudioObject;
    public GameObject player;
    public GameObject room;
    public SteamVR_Action_Vibration hapticAction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(transform.position, player.transform.position);

        if(dist< 2.5f) {
            Scene scene = SceneManager.GetActiveScene();
            Destroy(room);
            SceneManager.LoadScene(scene.name);
            hapticAction.Execute(0,1,150,1,SteamVR_Input_Sources.Any);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            AudioSource audioSrc = AudioObject.GetComponent<AudioSource>();
            RoundsController.deadEnemies++;
            audioSrc.Play();
            Destroy(gameObject);
            Debug.Log("Vampire dead");

            
            //other.gameObject.GetComponent<BoxCollider>().enabled = false;
        }

         Debug.Log("Collision" + other.gameObject.tag);
    }
}
