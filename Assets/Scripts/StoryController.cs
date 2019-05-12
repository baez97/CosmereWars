using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject roshar;
    public GameObject scadrial;
    public GameObject endgame;
    public GameObject syl;
    public GameObject kelsier;
    public static string ScadrialActive = "ScadrialActive";
    public static string RosharActive = "RosharActive";
    public static string EndgameActive = "EndgameActive";

    void Start()
    {
        int isScadrialActive = PlayerPrefs.GetInt(StoryController.ScadrialActive);
        int isRosharActive = PlayerPrefs.GetInt(StoryController.RosharActive);
        int isEndgameActive = PlayerPrefs.GetInt(StoryController.EndgameActive);
        if (isScadrialActive == 1){
            scadrial.SetActive(true);
            syl.SetActive(true);
        }
        if (isRosharActive == 1){
            roshar.SetActive(true);
        }

        if(isEndgameActive == 1){
            endgame.SetActive(true);
            kelsier.SetActive(true);
        }
    }

}
