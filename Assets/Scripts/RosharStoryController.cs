using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RosharStoryController : MonoBehaviour
{
    public GameObject syl;
    public GameObject sylFire;
    public GameObject sword;
    public GameObject swordFire;
    public GameObject enemyManager;
    public GameObject endgameFlowChart;
    public GameObject Room;
    public GameObject dialog;
    public GameObject endgame;
        public GameObject audioObj;

    public static int deadTrolls = 10;

    void Start(){
        PlayerPrefs.GetInt(StoryController.RosharDialog, 0);
        int dial = PlayerPrefs.GetInt(StoryController.RosharDialog);
        if(dial == 0){
            PlayerPrefs.SetInt(StoryController.RosharDialog, 1);
            dialog.SetActive(true);
        }else{
            TrollController.deathEnemies = 0;
            disableSyl();
            enableSword();
            enableEnemyManager();
            enableMovement();
            disableEndgame();
        }
    }

    void disableSyl(){
        syl.SetActive(false);
    }

    void disableEndgame(){
        endgame.SetActive(false);
    }

    void enableSylFire(){
        sylFire.SetActive(true);
    }

    void disableSylFire(){
        sylFire.SetActive(false);
    }

    void enableSword(){
        sword.SetActive(true);
    }

    void enableSwordFire(){
        swordFire.SetActive(true);
    }

    void disableSwordFire(){
        swordFire.SetActive(false);
    }

    void enableEnemyManager(){
        enemyManager.SetActive(true);
    }

    void enableEndgameFlowchart(){
        endgameFlowChart.SetActive(true);
    }

    void travelToCR(){
        Destroy(Room);
        SceneManager.LoadScene("CognitiveRealm");
        PlayerPrefs.SetInt(StoryController.ElantrisActive, 1);

    }

    void enableMovement(){
        SimpleVehicle.enable = true;
    }

        public void startAudio(){
        AudioSource audio = audioObj.GetComponent<AudioSource>();
        audio.Play();
    }

    public void stopAudio(){
        AudioSource audio = audioObj.GetComponent<AudioSource>();
        audio.Stop();
    }
}
