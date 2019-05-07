using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject roshar;
    public GameObject scadrial;
    public static string ScadrialActive = "ScadrialActive";
    public static string RosharActive = "RosharActive";
    void Start()
    {
        PlayerPrefs.SetInt(StoryController.ScadrialActive, 1);
        int isScadrialActive = PlayerPrefs.GetInt(StoryController.ScadrialActive);
        int isRosharActive = PlayerPrefs.GetInt(StoryController.RosharActive);
        if (isScadrialActive == 1){
            scadrial.SetActive(true);
        }
        if (isRosharActive == 1){
            roshar.SetActive(true);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
