using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR;

public class TrollController : MonoBehaviour
{
    Animator anim;
    private UnityEngine.AI.NavMeshAgent _nav;
    private Transform _player;
    public SteamVR_Action_Vibration hapticAction;

    bool faraway = false;
    public static bool endZone = false;
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
        if(!isDead && !endZone) {
            if(obj.gameObject.name == "Blade Collider" || obj.gameObject.tag == "FivePointStar" || obj.gameObject.tag == "P" || obj.gameObject.tag == "Coin") {

                //Deletes the troll body collider(Prevents from detecting the collision more than once)
                gameObject.transform.Find("troll_body_low").GetComponent<BoxCollider>().enabled=false;
                Debug.Log("Entro");

                //gameObject.transform.Find("mace_low").gameObject.tag = "DeadEnemy";
                this.gameObject.tag = "DeadEnemy";
                
                deathEnemies++;
                EnemyManager.deadEnemies++;

                _nav.isStopped = true;
                isDead = true;


                anim.SetLayerWeight(layer,0.0f);
                anim.SetTrigger("death");

                //Enables vibration
                hapticAction.Execute(0,0.5f,100,0.5f,SteamVR_Input_Sources.RightHand);

                AudioSource[] audios = GetComponents<AudioSource>();
                foreach( AudioSource audio in audios ) {
                    
                    audio.Play();
                }
            
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
