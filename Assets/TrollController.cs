using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollController : MonoBehaviour
{
    Animator anim;
    private UnityEngine.AI.NavMeshAgent _nav;
    private Transform _player;

    bool faraway = false;

    // Start is called before the first frame update
    void Start()
    {
        _nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
	    _player = GameObject.FindGameObjectWithTag("Player").transform;

        anim = GetComponent<Animator>();
    }
	
	void Update ()
	{
	    _nav.SetDestination(_player.position);
		Debug.Log("Go");

        if (_nav.remainingDistance >= 15.0f) {
            anim.SetTrigger("run");
            faraway = false;
        }

        if (_nav.remainingDistance < 10.0f)  {
            anim.SetTrigger("attack2");
            faraway = true;
        } 
	}
}
