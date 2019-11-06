using UnityEngine;
using System.Collections;

public class newMove : MonoBehaviour {
    private float speed = 15.0f;
    private float jumpForce = 35f;
    public BoxCollider bc;
    CharacterController cc;
    private bool isGrounded = true;
    public GameObject character;
    Animator anim;
    private float xPos;
    private float zPos;

   //Rigidbody rig;
    public int stage;
    private Vector3 moveDirection;
    private Vector3 moveVertComponent = new Vector3(0, 0, 0);
    public float m_GravityScale = 10f;

    void Start()
    {

        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        // rig = GetComponent<Rigidbody>();
        //health = GetComponent<PRINCESS.Core.Health>();
    }

    void Update()
    {
        // Physics.gravity = new Vector3(0, -15f, 0);

        /*if (health.IsDead())
        {
            anim.SetBool("die", true);
            return;
        }*/

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("attack", true);
            Fight();
        }

        if (cc.isGrounded)
        {
            // if on the ground, set small downward force to cancel out jitter
            moveVertComponent.y = Physics.gravity.y * m_GravityScale * Time.deltaTime;

            // jump when on the ground and X is pressed
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveVertComponent.y = jumpForce;
                // animator.Jump();
            }
        }
        else
        {
            // accelerate down due to gravity
            moveVertComponent.y += Physics.gravity.y * m_GravityScale * Time.deltaTime;
        }
        cc.Move(moveVertComponent * Time.deltaTime);

        if (stage == 2)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                character.transform.rotation = Quaternion.Euler(0, 90, 0);
                anim.SetBool("walk", true);

                character.transform.position += new Vector3(1, 0, 0) * speed * Time.deltaTime;
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                character.transform.rotation = Quaternion.Euler(0, 270, 0);
                anim.SetBool("walk", true);
                character.transform.position += new Vector3(-1, 0, 0) * speed * Time.deltaTime;
            }

            else
            {
                anim.SetBool("walk", false);
                anim.SetBool("idle", true);
            }
            character.transform.position = new Vector3(character.transform.position.x, character.transform.position.y, zPos);

        }
        else
        {

            if (Input.GetKey(KeyCode.RightArrow))
            {
                character.transform.rotation = Quaternion.Euler(0, 0, 0);
                // anim.SetBool("HeroRun", true);
                anim.SetBool("walk", true);

                character.transform.position += new Vector3(0, 0, 1) * speed * Time.deltaTime;
            }

            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                character.transform.rotation = Quaternion.Euler(0, 180, 0);
                // anim.SetBool("HeroRun", true);
                anim.SetBool("walk", true);
                character.transform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;
            }

            else
            {
                anim.SetBool("walk", false);
                anim.SetBool("idle", true);
            }
            character.transform.position = new Vector3(xPos, character.transform.position.y, character.transform.position.z);

        }
        // if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //     //rig.velocity.y = 1f;
        // }

        // lock x-axis

    }

    private void Fight()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, 10.0F);
        foreach (RaycastHit hit in hits)
        {
            //PRINCESS.Fight.FightTarget target = hit.transform.GetComponent<PRINCESS.Fight.FightTarget>();
            //if (target == null) continue;
            //if (!GetComponent<PRINCESS.Fight.Fighter>().ShouldAttack(target.gameObject)) continue;


            // GetComponent<PRINCESS.Fight.Fighter>().Attack(target.gameObject);
            //PRINCESS.Core.Health targetHealth = target.GetComponent<PRINCESS.Core.Health>();
            //if (targetHealth == null) return;
            //targetHealth.CauseDamage(10f);
        }
    }

    //void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Coin"))
    //    {
    //        collision.gameObject.SetActive(false);
    //        Destroy(collision.gameObject);
    //        // Add point
    //    }
    //    else if (collision.gameObject.CompareTag("Diamond"))
    //    {
    //        collision.gameObject.SetActive(false);
    //        Destroy(collision.gameObject);
    //        // Add point
    //    }
    //}

    // void OnCollisionExit(Collision collision)
    // {
    //     Debug.Log("Exited");
    //     if (collision.gameObject.CompareTag("Plane"))
    //     {
    //         isGrounded = false;
    //     }
    // }
    /*
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
    */
}
