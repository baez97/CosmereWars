using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleCollisionEvent : MonoBehaviour
{
    // Start is called before the first frame update

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void removeApple(GameObject apple) {
        Destroy(apple);
    }
}
