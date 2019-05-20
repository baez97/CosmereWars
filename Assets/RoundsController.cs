using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundsController : MonoBehaviour
{
    // Start is called before the first frame update

    int round;
    public static int deadEnemies;

    int[] enemies_per_round = {4,2,3};

    public GameObject room;

    void Start()
    {
        round = 1;
        deadEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(deadEnemies >= enemies_per_round[round]) {
            Debug.Log("Nueva ronda");
            deadEnemies=0;
            round++;

            if(round<4) {
                GameObject camera = GameObject.Find("CameraRound" + round);
                camera.SetActive(true);

                GameObject floor = GameObject.Find("PlaneRound" + round);
                floor.SetActive(true);
            }
            else
            {
                Destroy(room);
                SceneManager.LoadScene("CongnitiveRealm");
            }
            

        }

    }

    void OnBecameVisible()
    {
        //Desactivamos el detector de la ronda actual
        GameObject camera = GameObject.Find("CameraRound" + round);
        camera.SetActive(false);

        //Activamos el conjunto de enemigos de la ronda actual
        GameObject enemyRound = GameObject.Find("Round" + round);
        enemyRound.SetActive(true);

        Debug.Log("Visible");
    }
}
