using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject elantris;
    public GameObject scadrial;
    public GameObject roshar;
    public GameObject endgame;
    public GameObject syl;
    public GameObject kelsier;
    public GameObject raoden;
    public GameObject sylDialog;
    public GameObject kelsierDialog;
    public GameObject raodenDialog;
    
    public static string ScadrialActive = "ScadrialActive";
    public static string ElantrisActive = "ElantrisActive";
    public static string EndgameActive = "EndgameActive";
    public static string RosharDialog = "RosharDialog";


    void Start()
    {

        PlayerPrefs.SetInt(StoryController.EndgameActive,1);
        int isScadrialActive = PlayerPrefs.GetInt(StoryController.ScadrialActive);
        int isElantrisActive = PlayerPrefs.GetInt(StoryController.ElantrisActive);
        int isEndgameActive = PlayerPrefs.GetInt(StoryController.EndgameActive);
        if (isScadrialActive == 1){
            scadrial.SetActive(true);
            raoden.SetActive(true);
        }
        if (isElantrisActive == 1){
            elantris.SetActive(true);
            syl.SetActive(true);
        }

        if(isEndgameActive == 1){
            endgame.SetActive(true);
            kelsier.SetActive(true);
            elantris.SetActive(false);
            roshar.SetActive(false);
            scadrial.SetActive(false);

        }
    }

    void disableSylDialog(){
        sylDialog.SetActive(false);
    }

    void disableRaodenDialog(){
        raodenDialog.SetActive(false);
    }

    void disableKelsierDialog(){
        kelsierDialog.SetActive(false);
    }

}
