using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RosharStoryController : MonoBehaviour
{
    public GameObject syl;
    public GameObject sylFire;
    public GameObject sword;
    public GameObject swordFire;

    void disableSyl(){
        syl.SetActive(false);
    }

    void enableSylFire(){
        sylFire.SetActive(true);
    }

    void disableSylFire(){
        sylFire.SetActive(false);
    }

    void enableSword(){
        sword.SetActive(true);
    }

    void enableSwordFire(){
        swordFire.SetActive(true);
    }

    void disableSwordFire(){
        swordFire.SetActive(false);
    }
}
