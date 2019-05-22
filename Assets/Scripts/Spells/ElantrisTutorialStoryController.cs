using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ElantrisTutorialStoryController : MonoBehaviour
{
    public GameObject spells;
    public GameObject room;
    public GameObject audioObj;
    public void enableSpells(){
        spells.SetActive(true);
    }

    public void travelToEFB(){
        Destroy(room);
        SceneManager.LoadScene("ElantrisFinalBattle");
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
