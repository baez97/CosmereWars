using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundsController : MonoBehaviour
{
    // Start is called before the first frame update

    int round = 1;
    public static int deadEnemies;

    int[] enemies_per_round = {4,2,3};

    public GameObject room;

    public GameObject player;

    public float distaceThreshold;
    public Transform[] points;
    public GameObject[] rounds;
    public GameObject[] areas;

    void Start()
    {
        deadEnemies = 0;

    }

    // Update is called once per frame
    void Update()
    {
        checkDistance();

        if(deadEnemies >= enemies_per_round[round-1]) {
            Debug.Log("Nueva ronda");
            deadEnemies=0;
            round++;

            if(round<4) {

                GameObject floor = areas[round-1];
                floor.SetActive(true);
            }
            else
            {
                Destroy(room);
                SceneManager.LoadScene("CognitiveRealm");
            }
            

        }

    }


    public void checkDistance() {

        float dist = Vector3.Distance(transform.position, points[round-1].position);
        //float dist = 12;
        Debug.Log("Distance: " + dist);
        
        if(dist<distaceThreshold) {
            GameObject enemyRound = rounds[round-1];
            enemyRound.SetActive(true);
            Debug.Log("Visible");
        }
    }
}
