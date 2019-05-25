using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public GameObject room;
   
    void OnCollisionEnter (Collision col)
    {

        if(col.gameObject.CompareTag("WorldPortal"))
        {
            if (col.gameObject.name == "NewGame"){
                PlayerPrefs.SetInt(StoryController.RosharDialog, 0);
                PlayerPrefs.SetInt(StoryController.ScadrialActive, 0);
                PlayerPrefs.SetInt(StoryController.ElantrisActive, 0);
                PlayerPrefs.SetInt(StoryController.EndgameActive, 0);
                PlayerPrefs.SetInt(StoryController.GameFinished, 0);

            }
			Destroy (room);
            Destroy(col.gameObject);
            SceneManager.LoadScene("CognitiveRealm");
        }
    }
}
