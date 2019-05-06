  // Patrol.cs
    using UnityEngine;
    using UnityEngine.AI;
    using System.Collections;


    public class Patrol : MonoBehaviour {

        public GameObject[] points;
        private int destPoint = 0;
        private NavMeshAgent agent;


        void Start () {
            agent = GetComponent<NavMeshAgent>();

            // Disabling auto-braking allows for continuous movement
            // between points (ie, the agent doesn't slow down as it
            // approaches a destination point).
            agent.autoBraking = false;

            destPoint = Random.Range (0, points.Length);

            this.agent.transform.position = points[destPoint].transform.position;
            
            GotoNextPoint();
        }


        void GotoNextPoint() {
            // Returns if no points have been set up

            // Choose the next point in the array as the destination,
            // cycling to the start if necessary.
            destPoint = (destPoint + 1) % points.Length;
            Debug.Log("Next point: " + destPoint);

            // Set the agent to go to the currently selected destination.
            this.agent.SetDestination(points[destPoint].transform.position);
        }


        void Update () {
            // Choose the next destination point when the agent gets
            // close to the current one.
           
            if (!agent.pathPending && agent.remainingDistance < 0.5f) {
                GotoNextPoint();
    
            }
        }
    }