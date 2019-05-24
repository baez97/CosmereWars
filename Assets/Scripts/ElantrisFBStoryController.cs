using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ElantrisFBStoryController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Room;
        public GameObject audioObj;

    void travelToCR(){
        Destroy(Room);
        SceneManager.LoadScene("CognitiveRealm");
        PlayerPrefs.SetInt(StoryController.ScadrialActive, 1);
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
