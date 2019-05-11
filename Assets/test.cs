using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider obj) {
        Debug.Log("Died1");
        
        if(obj.gameObject.name == "Sword") {
            Debug.Log("Died");
        }
    }
}
