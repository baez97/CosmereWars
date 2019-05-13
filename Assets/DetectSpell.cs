using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSpell : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isP = false;
    private bool isStar = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isP && isStar) {
            Debug.Log("Has terminado tutoria");
        
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
