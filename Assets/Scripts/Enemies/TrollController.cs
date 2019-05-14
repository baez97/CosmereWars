using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrollController : MonoBehaviour
{
    Animator anim;
    private UnityEngine.AI.NavMeshAgent _nav;
    private Transform _player;

    bool faraway = false;
    int layer = 1;
    bool isDead = false;

    System.Random gen;
    
    public static int deathEnemies = 0;

    // Start is called before the first frame update
    void Start()
    {
        _nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
	    _player = GameObject.FindGameObjectWithTag("Player").transform;

        anim = GetComponent<Animator>();
        anim.SetTrigger("run");
        gen = new System.Random();
    }
	
	void Update ()
	{
        if (!isDead) {
	        _nav.SetDestination(_player.position);

            if (_nav.remainingDistance < 30.0f && faraway == false) {
                layer = gen.Next(1,3);
                anim.SetLayerWeight(layer,0.8f);
                faraway = true;
            }
            else if(_nav.remainingDistance >= 30.0f && faraway) {
                anim.SetLayerWeight(layer,0.0f);
                faraway = false;
            }
        }
        
	}

    void OnTriggerEnter(Collider obj) {

        Debug.Log("Enemy collided: " + obj.gameObject.name);
        if(!isDead) {
            if(obj.gameObject.name == "Blade Collider" || obj.gameObject.tag == "FivePointStar" || obj.gameObject.tag == "P") {

                //Deletes the troll body collider(Prevents from detecting the collision more than once)
                gameObject.transform.Find("troll_body_low").GetComponent<BoxCollider>().enabled=false;
                Debug.Log("Entro");

                deathEnemies++;

                _nav.isStopped = true;
                isDead = true;


                anim.SetLayerWeight(layer,0.0f);
                anim.SetTrigger("death");
            
                //Wait time before delete gameObject
                StartCoroutine(Example());
            }
        }
       
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
      
    }

}
