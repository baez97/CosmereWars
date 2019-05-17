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
    void travelToCR(){
        Destroy(Room);
        SceneManager.LoadScene("CognitiveRealm");
        PlayerPrefs.SetInt(StoryController.EndgameActive, 1);
    }

    void enableKey(){
        key.GetComponent<MeshCollider>().enabled = true;
    }
}
}
