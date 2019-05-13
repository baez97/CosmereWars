using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DetectSpell : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isP = false;
    private bool isStar = false;

    public GameObject room;

    // Update is called once per frame
    void Update()
    {
        if (isP && isStar) {
            Debug.Log("Has terminado tutorial");
            Destroy(room);
            SceneManager.LoadScene("ElantrisFinalBattle");
        } 
    }
    

     private void OnTriggerEnter(Collider other) {

            if(other.gameObject.tag == "FivePointStar") {
                isStar = true;
            }

            if(other.gameObject.tag == "P") {
                isP = true;
            }

            Debug.Log("Recibido");
        
    }
}
