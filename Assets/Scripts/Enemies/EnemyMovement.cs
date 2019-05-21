using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private NavMeshAgent _nav;
    private Transform _player;
	private Animator anim;
	public bool isDead = false;

	void Start ()
	{
	    _nav = GetComponent<NavMeshAgent>();
	    _player = GameObject.FindGameObjectWithTag("Player").transform;
		anim = GetComponent<Animator>();
        anim.SetTrigger("Run");
	}
	
	void Update ()
	{
	    _nav.SetDestination(_player.position);
		Debug.Log("Ataca");
	}

	


}