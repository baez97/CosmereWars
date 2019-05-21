using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ElantrisFBStoryController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Room;
    void travelToCR(){
        Destroy(Room);
        SceneManager.LoadScene("CognitiveRealm");
        PlayerPrefs.SetInt(StoryController.ScadrialActive, 1);
    }
}
