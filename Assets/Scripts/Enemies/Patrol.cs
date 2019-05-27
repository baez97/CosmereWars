  // Patrol.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;


    public class Patrol : MonoBehaviour {

        public GameObject[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;
        bool activated = false;

        Animator anim;


        public GameObject body;
        public GameObject weapon;
        public GameObject endgame;

        void GotoNextPoint() {
            // Returns if no points have been set up

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
            Debug.Log("Next point: " + destPoint);

            // Set the agent to go to the currently selected destination.
            this.agent.SetDestination(points[destPoint].transform.position);
        }

        private void Start() {
            body.GetComponent<SkinnedMeshRenderer>().enabled=false;
            weapon.GetComponent<MeshRenderer>().enabled=false;

            anim = GetComponent<Animator>();
            anim.SetTrigger("Run");
        }


        void Update () {
            // Choose the next destination point when the agent gets
            // close to the current one.
        

            if (activated && !agent.pathPending && agent.remainingDistance < 0.5f) {
                GotoNextPoint();
                Debug.Log("SD1");
            }

            if (TrollController.deathEnemies >= RosharStoryController.deadTrolls && activated == false) {
                
                body.GetComponent<SkinnedMeshRenderer>().enabled=true;
                weapon.GetComponent<MeshRenderer>().enabled=true;
                
                agent = GetComponent<NavMeshAgent>();
                agent.autoBraking = false;

                destPoint = Random.Range (0, points.Length);
                transform.position = points[destPoint].transform.position;
                Debug.Log(destPoint);
            
                GotoNextPoint();

                activated = true;
            }
        }

        void OnTriggerEnter(Collider obj) {

            Debug.Log("Enemy collided: " + obj.gameObject.name);

            if(obj.gameObject.name == "Blade Collider") {
                AudioSource[] audios = GetComponents<AudioSource>();
                foreach( AudioSource audio in audios ) {
                    audio.Play();
                }
                endgame.SetActive(true);
                TrollController.endZone = true;
                Destroy(gameObject);
            }
        
        }
    }