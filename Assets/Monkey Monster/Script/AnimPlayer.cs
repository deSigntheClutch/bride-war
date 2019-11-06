using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AnimPlayer : MonoBehaviour {
    public  float speed;
    Animator anim;
    // Vector3 moveDir = Vector3.zero;
    public Transform[] moveSpots;
    private int randomSpot;
    public float radius = 10f;
    public Vector3 patrolPoint;
    public float patrolSpeed = 4f;
    NavMeshAgent agent;
     
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        patrolPoint = RandomPatrolPoint();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("isPatrol", true);
        anim.SetBool("Attack", false);
        Patrol(); 

    }

  
    public Vector3 RandomPatrolPoint() {
        Vector3 randomPoint = (Random.insideUnitSphere * radius) + transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPoint, out navHit, radius, -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    }


    public void Patrol() { 
        if (Vector3.Distance(transform.position, patrolPoint) < 2f) {
            patrolPoint = RandomPatrolPoint();
        } else {
            agent.SetDestination(patrolPoint);
        }
    }
}
