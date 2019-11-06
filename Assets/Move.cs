using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using PRINCESS.Core;

namespace PRINCESS.Movement
{
    public class Move : MonoBehaviour, CAction
    {
        NavMeshAgent navMeshAgent;
        Ray currentRay;
        Health health;
        public void Start()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }
        // Update is called once per frame
        void Update()
        {
            navMeshAgent.enabled = !health.IsDead();
            DisplayAnimator();
        }
        public void StartMove(Vector3 destination) {
            GetComponent<ActionScheduler>().StartAction(this); 
            MoveTo(destination);
        }

        public void MoveTo(Vector3 destination)
        {
            GetComponent<NavMeshAgent>().destination = destination;
            navMeshAgent.isStopped = false;
        }

        public void Cancel() {
            navMeshAgent.isStopped = true;
        }

        private void DisplayAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 localVelocity = transform.InverseTransformDirection(velocity);
            float speed = localVelocity.z;
            GetComponent<Animator>().SetFloat("forwardSpeed", speed);
        }
    }
}

