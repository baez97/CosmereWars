using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RoundsController : MonoBehaviour
{
    // Start is called before the first frame update

    private int round = 0;
    public static int deadEnemies;

    int[] enemies_per_round = {4,2,3};

    public GameObject room;

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

        if(deadEnemies >= enemies_per_round[round]) {
            Debug.Log("Nueva ronda");
            deadEnemies=0;
            if ( round < 2 )
                round++;
            Debug.Log("Enable round");
            GameObject floor = areas[round];
            floor.SetActive(true);
        }

    }


    public void checkDistance() {
        if ( round < 3 ) {
            Debug.Log("La ronda es: " + round);
            float dist = Vector3.Distance(transform.position, points[round].position);
            //float dist = 12;
            Debug.Log("Distance: " + dist);
            
            if(dist<distaceThreshold) {
                GameObject enemyRound = rounds[round];
                Debug.Log("My name: " + enemyRound.name);
                enemyRound.SetActive(true);
                Debug.Log("Es Visible");
            }
        }
    }
}
