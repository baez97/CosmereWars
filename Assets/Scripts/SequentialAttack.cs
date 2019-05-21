using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequentialAttack : MonoBehaviour
{
    
    void OnCollisionEnter (Collision col)
    {
        if(col.gameObject.tag == "Coin")
        {
            Destroy(gameObject);
            RoundsController.deadEnemies++;
        }
    }
}
