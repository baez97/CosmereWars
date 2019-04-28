using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeadController : MonoBehaviour
{
	public GameObject room;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Elantris", 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter (Collision col)
    {
        Debug.Log("Collision" + col.gameObject.name);


        if(col.gameObject.CompareTag("WorldPortal") && PlayerPrefs.GetInt(col.gameObject.name) == 1)
        {
			Destroy (room);
            SceneManager.LoadScene(col.gameObject.name);
			Destroy(col.gameObject);
        }
    }
}
