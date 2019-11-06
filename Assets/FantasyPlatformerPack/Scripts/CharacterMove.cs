using UnityEngine;
using System.Collections;

public class CharacterMove : MonoBehaviour {

	public float maxSpeed = 6.0f; //Maximum movement speed
	public bool facingRight = true; //Where player faced at start, 
									//if he looking to right set to true,
									//if he looking to left, set to false
	public float jumpSpeed = 500.0f; //Jump speed
	public GameObject jumpDust; //Particles when jumping and landing
	private float moveDirection; //Moving direction
	private Rigidbody rgb; //Rigidbody component
	public float gravity = 10; //Gravity multiplier

	private Transform footTrigger;
	private Animator anim; //Animator Component
	private bool jump; //if jump animation is playing now
    
	void Awake(){
		footTrigger = GameObject.Find("FootTrigger").transform;
		//Get Player Rigidbody Component
		rgb = gameObject.GetComponent<Rigidbody>();
		rgb.sleepThreshold = 0.0f;
		//Get Player Animator
		anim = GetComponentInChildren<Animator>();
	}

	void FixedUpdate () {
		//Apply movement to character
		rgb.velocity = new Vector2(moveDirection * maxSpeed, rgb.velocity.y);
		//When player change movement direction (Left,Right), flip character
		if(moveDirection > 0.0f && !facingRight || moveDirection < 0.0f && facingRight)
		Flip();
		//Apply additional gravity to character
		rgb.AddForce(new Vector2(0, -1.0f * gravity));
	}

	void Update () {
        Debug.Log(jump);

        //Check for Input
        if (Input.GetAxis("Horizontal") != 0)
		{
			//Play footstep sound
			if(!jump)
			{
				//Apply movement animation in Mecanim
				anim.SetBool("Walking",true);
			}
			//Set moving direction
			moveDirection = Input.GetAxis("Horizontal");
		}
		else
		{
			if(!jump)
			//Turn off movement animation and apply Idle animation in Mecanim
			    anim.SetBool("Walking", false);
			//Stop footstep sound
		}
		//Check for Input, check if character grounded
		if(!jump && Input.GetButtonDown("Jump"))
		{
			//Play jump sound (if exists)
			if(jumpDust)
			    Instantiate(jumpDust,footTrigger.position,Quaternion.identity);
			rgb.AddForce(new Vector2(0, jumpSpeed));
			//Apply Jump animation in Mecanim
			anim.SetBool("Jump",true);
			jump = true;
		}
	}

	public void Land()
	{
		//When player lands, play Land animation in Mecanim
		if(jump == true)
		{	
			if(jumpDust)
			    Instantiate(jumpDust, footTrigger.position, Quaternion.identity);
			jump = false;
			anim.SetBool("Jump", false);
		}
	}

	void Flip(){
		//Flip character from left to right and vice versa
		facingRight = !facingRight;
		transform.Rotate(Vector3.up, 180.0f, Space.World);
	}
}
