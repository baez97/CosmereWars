using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int lives = 1;
    public GameObject room;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("Player Controller running");
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            lives--;
            Debug.Log("You've been hit: Lives " + lives);
            if(lives <=0) {
                Scene scene = SceneManager.GetActiveScene();
                Destroy(room);
                SceneManager.LoadScene(scene.name);
            }
        }
    }
}
