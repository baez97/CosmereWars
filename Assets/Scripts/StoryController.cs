using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject elantris;
    public GameObject scadrial;
    public GameObject endgame;
    public GameObject syl;
    public GameObject kelsier;
    public static string ScadrialActive = "ScadrialActive";
    public static string ElantrisActive = "ElantrisActive";
    public static string EndgameActive = "EndgameActive";

    void Start()
    {
        int isScadrialActive = PlayerPrefs.GetInt(StoryController.ScadrialActive);
        int isElantrisActive = PlayerPrefs.GetInt(StoryController.ElantrisActive);
        int isEndgameActive = PlayerPrefs.GetInt(StoryController.EndgameActive);
        if (isScadrialActive == 1){
            scadrial.SetActive(true);
            syl.SetActive(true);
        }
        if (isElantrisActive == 1){
            elantris.SetActive(true);
        }

        if(isEndgameActive == 1){
            endgame.SetActive(true);
            kelsier.SetActive(true);
        }
    }

}
