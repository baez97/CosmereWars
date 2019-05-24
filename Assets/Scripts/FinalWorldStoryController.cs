using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalWorldStoryController : MonoBehaviour
{

    public GameObject Room;
        public GameObject audioObj;


    void travelToCR(){
        Destroy(Room);
        SceneManager.LoadScene("CognitiveRealm");
        PlayerPrefs.SetInt(StoryController.GameFinished, 1);
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
