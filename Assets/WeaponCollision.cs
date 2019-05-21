using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{

    public GameObject otherWeapon;

    private void Update() {
      
        transform.position = otherWeapon.transform.position;
        transform.rotation = otherWeapon.transform.rotation;
    }

    void OnTriggerEnter (Collider col)
    {
       Debug.Log("Hola, buenas tardes");
    }

    void OnCollisionEnter (Collision col)
    {
        Debug.Log("Holi: " + col.gameObject.tag);

        
    }


}
