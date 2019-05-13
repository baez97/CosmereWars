using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ElantrisTutorialStoryController : MonoBehaviour
{
    public GameObject spells;
    public GameObject room;
    public void enableSpells(){
        spells.SetActive(true);
    }

    public void travelToEFB(){
        Destroy(room);
        SceneManager.LoadScene("ElantrisFinalBattle");
    }
}
