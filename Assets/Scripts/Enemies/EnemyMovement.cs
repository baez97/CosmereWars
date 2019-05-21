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

	void OnTriggerEnter(Collider obj) {

        Debug.Log("Enemy collided: " + obj.gameObject.name);
        if(!isDead) {
            if(obj.gameObject.tag == "Coin") {

                //Deletes the troll body collider(Prevents from detecting the collision more than once)
                gameObject.transform.Find("troll_body_low").GetComponent<BoxCollider>().enabled=false;
                Debug.Log("Entro");

                //gameObject.transform.Find("mace_low").gameObject.tag = "DeadEnemy";
                this.gameObject.tag = "DeadEnemy";
                
                deathEnemies++;

                _nav.isStopped = true;
                isDead = true;


                anim.SetLayerWeight(layer,0.0f);
                anim.SetTrigger("death");

                //Enables vibration
                hapticAction.Execute(0,0.5f,100,0.5f,SteamVR_Input_Sources.RightHand);

                AudioSource audio = GetComponent<AudioSource>();
                audio.Play();
            
                //Wait time before delete gameObject
                StartCoroutine(Example());
            }
        }
       
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
      
    }
}