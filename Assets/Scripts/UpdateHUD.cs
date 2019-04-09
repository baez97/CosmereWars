using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class UpdateHUD : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FailedShoot(Text lifes) {
        int count = Int32.Parse(lifes.ToString());
        count-=1;

        if (count <= 0) {
            lifes.text = "GAME OVER";
        }
        else {
            lifes.text = "" + count;
        }
    }
}
