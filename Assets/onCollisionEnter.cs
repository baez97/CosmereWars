﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onCollisionEnter : MonoBehaviour
{
    void OnCollisionEnter(Collision col)
    {
        Debug.Log("COLLIDED!!!");
    } 
}
