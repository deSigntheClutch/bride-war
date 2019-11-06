using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BossAi : MonoBehaviour
{

    public float lookRadius = 15f;
    public float stopChasing = 4f;
    Transform target;
    NavMeshAgent agent;
    GameObject player;
    Animator ani;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        target = player.transform;
        agent = GetComponent<NavMeshAgent>();
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(target.position, transform.position);
        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            ani.SetBool("iswalk", true);
            ani.SetBool("isstand", false);
            if (distance < stopChasing)
            {
                ani.SetBool("iswalk", false);
                ani.SetBool("isstand", true);
                agent.isStopped = true;
                agent.ResetPath();
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
