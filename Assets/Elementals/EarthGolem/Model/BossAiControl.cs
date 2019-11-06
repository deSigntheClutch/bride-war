using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PRINCESS.Fight;
using PRINCESS.Movement;
using PRINCESS.Core;
using System;

namespace PRINCESS.Controller
{
    public class BossAiControl : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 10f;
        [SerializeField] PatrolPath patrolPath;
        [SerializeField] float atPatrolPointTolerance = 2f;
        [SerializeField] float timeDwellAtPatrolPoint = 3f;
        Vector3 guardPosition;
        [SerializeField] float suspicionTime = 3f;
        float timeFromLastSaw = Mathf.Infinity;
        float timeFromDwellAtPatrolPoint = Mathf.Infinity;
        GameObject player;
        BossFight fighter;
        Move move;
        Health health;
        int currentPatrolPoint = 0;
        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            fighter = GetComponent<BossFight>();
            move = GetComponent<Move>();
            health = GetComponent<Health>();
            guardPosition = transform.position;
        }
        // Update is called once per frame
        void Update()
        {
            if (health.IsDead()) return;
            //chase and attack
            if (DistanceToPlayer() < chaseDistance && fighter.ShouldAttack(player))
            {
                timeFromLastSaw = 0;
                fighter.Attack(player);
            }
            // suspious 
            else if (timeFromLastSaw < suspicionTime)
            {
                SuspiousState();
            }
            // back to patrol
            else
            {
                PatrolState();
            }
            timeFromLastSaw += Time.deltaTime;
            timeFromDwellAtPatrolPoint += Time.deltaTime;
        }

        private void SuspiousState()
        {
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private void PatrolState()
        {
            Vector3 nextPosition = guardPosition;
            if (patrolPath != null)
            {
                if (AtPatrolPotint())
                {
                    timeFromDwellAtPatrolPoint = 0;
                    RunPatrolCircle();
                }
                nextPosition = GetCurrentPatrolPoint();
            }
            if (timeFromDwellAtPatrolPoint > timeDwellAtPatrolPoint)
            {
                move.StartMove(nextPosition);
            }
        }

        private void RunPatrolCircle()
        {
            currentPatrolPoint = patrolPath.GetNextIndex(currentPatrolPoint);
        }

        private Vector3 GetCurrentPatrolPoint()
        {
            return patrolPath.GetPatrolPointPosition(currentPatrolPoint);
        }

        private bool AtPatrolPotint()
        {
            float distanceToThePatrolPoint = Vector3.Distance(transform.position, GetCurrentPatrolPoint());
            return distanceToThePatrolPoint < atPatrolPointTolerance;
        }

        private float DistanceToPlayer()
        {
            return Vector3.Distance(player.transform.position, transform.position);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}