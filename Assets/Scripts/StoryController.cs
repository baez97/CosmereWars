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
    public GameObject oldText;
    public GameObject endText;
    public GameObject gameFinished;
    public GameObject audioSyl;
    public GameObject audioRaoden;
    public GameObject audioKelsier;


    
    public static string ScadrialActive = "ScadrialActive";
    public static string ElantrisActive = "ElantrisActive";
    public static string EndgameActive = "EndgameActive";
    public static string GameFinished = "GameFinished";
    public static string RosharDialog = "RosharDialog";


    void Start()
    {
        // PlayerPrefs.SetInt(StoryController.ScadrialActive, 0);
        // PlayerPrefs.SetInt(StoryController.ElantrisActive, 0);
        // PlayerPrefs.SetInt(StoryController.EndgameActive, 0);
        // PlayerPrefs.SetInt(StoryController.GameFinished, 0);

        int isScadrialActive = PlayerPrefs.GetInt(StoryController.ScadrialActive);
        int isElantrisActive = PlayerPrefs.GetInt(StoryController.ElantrisActive);
        int isEndgameActive = PlayerPrefs.GetInt(StoryController.EndgameActive);
        int isGameFinished = PlayerPrefs.GetInt(StoryController.GameFinished);

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

        if(isGameFinished == 1){
            gameFinished.SetActive(true);
            oldText.SetActive(false);
            endText.SetActive(true);
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

    public void startAudioSyl(){
        AudioSource audio = audioSyl.GetComponent<AudioSource>();
        audio.Play();
    }

    public void stopAudioSyl(){
        AudioSource audio = audioSyl.GetComponent<AudioSource>();
        audio.Stop();
    }

    public void startAudioKelsier(){
        AudioSource audio = audioKelsier.GetComponent<AudioSource>();
        audio.Play();
    }

    public void stopAudioKelsier(){
        AudioSource audio = audioKelsier.GetComponent<AudioSource>();
        audio.Stop();
    }

    public void startAudioRaoden(){
        AudioSource audio = audioRaoden.GetComponent<AudioSource>();
        audio.Play();
    }

    public void stopAudioRaoden(){
        AudioSource audio = audioRaoden.GetComponent<AudioSource>();
        audio.Stop();
    }

}
