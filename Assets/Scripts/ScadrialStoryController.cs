using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Valve.VR.InteractionSystem.Sample
{
public class ScadrialStoryController : MonoBehaviour
{
    public GameObject Room;
    public GameObject key;
        public GameObject audioObj;

    void travelToCR(){
        Destroy(Room);
        SceneManager.LoadScene("CognitiveRealm");
        PlayerPrefs.SetInt(StoryController.EndgameActive, 1);
    }

    void enableKey(){
        key.GetComponent<MeshCollider>().enabled = true;
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
}
