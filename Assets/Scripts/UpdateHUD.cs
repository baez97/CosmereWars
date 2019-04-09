using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class UpdateHUD : MonoBehaviour
{
    int count = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FailedShoot(Text lifes) {
        count-=1;

        if (count <= 0) {
            lifes.text = "GAME OVER";
            Debug.Log("Game Over");
        }
        else {
            lifes.text = "" + count;
            Debug.Log("Dead man");
        }
    }
}
