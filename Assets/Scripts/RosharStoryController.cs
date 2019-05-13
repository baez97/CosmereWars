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

    void disableSyl(){
        syl.SetActive(false);
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
}
