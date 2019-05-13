using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiveStar : MonoBehaviour
{
    public GameObject tracked_obj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float dist = Vector3.Distance(tracked_obj.transform.position, transform.position);

        if (dist < 5.0f && !Spells.enableStar) {
            Debug.Log("ACTIVANDO LA ESTRELLA");
            Spells.enableStar = true;
        }
    }
}
