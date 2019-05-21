﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadController : MonoBehaviour
{
	public GameObject room;
        public int lives = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision col)
    {

        if(col.gameObject.CompareTag("WorldPortal"))
        {
			Destroy (room);
            if (col.gameObject.name == "Roshar"){
                PlayerPrefs.SetInt(StoryController.RosharDialog, 0);
            }
            SceneManager.LoadScene(col.gameObject.name);

			Destroy(col.gameObject);
        }
    }
}
