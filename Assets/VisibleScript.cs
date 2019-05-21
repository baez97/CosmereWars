using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisibleScript : MonoBehaviour
{
    public GameObject player;
    public GameObject round;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if(player.GetComponent<Renderer>().isVisible){
          Debug.Log("It is visible");
          round.SetActive(true);
      }  
    }
}
