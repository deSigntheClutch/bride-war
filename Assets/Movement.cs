using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 30.0f;
    private float jumpForce = 40f;
    public BoxCollider bc;
    CharacterController cc;
    private bool isGrounded = true;
    public GameObject character;
    Animator anim;
    public float xPos;
    public PRINCESS.Core.Health health;
    // Rigidbody rig;
    private int currentCoinCount;
    public CoinDisplay CoinController;
    private int currentDiamondCount;
    public DiamondDisplay DiamondController;

    private Vector3 moveDirection;
    private Vector3 moveVertComponent = new Vector3(0, 0, 0);
    public float m_GravityScale = 10f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        // rig = GetComponent<Rigidbody>();
        health = GetComponent<PRINCESS.Core.Health>();
        currentCoinCount = 0;
    }

    void Update()
    {
        // Physics.gravity = new Vector3(0, -15f, 0);
        
        if (health.IsDead()) {
            anim.SetBool("die", true);
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetBool("attack", true);
            GetComponent<Sounds>().PlayAttack1();
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
        } else {
            // accelerate down due to gravity
            moveVertComponent.y += Physics.gravity.y * m_GravityScale * Time.deltaTime;
        }
        cc.Move(moveVertComponent * Time.deltaTime);


        
        if (Input.GetKey(KeyCode.RightArrow))
        {
            character.transform.rotation = Quaternion.Euler(0, 0, 0);
            // anim.SetBool("HeroRun", true);
            anim.SetBool("walk", true);

            character.transform.position += new Vector3(0, 0, 1)  * speed * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            character.transform.rotation = Quaternion.Euler(0, 180, 0);
            // anim.SetBool("HeroRun", true);
            anim.SetBool("walk", true);
            character.transform.position += new Vector3(0, 0, -1) * speed * Time.deltaTime;
        }

        else {
            anim.SetBool("walk", false);
            anim.SetBool("idle", true);
        }
        // if (isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
        // {
        //     rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        //     //rig.velocity.y = 1f;
        // }

        // lock x-axis
        character.transform.position = new Vector3(xPos, character.transform.position.y, character.transform.position.z);

    }

    private void Fight()
    {
        RaycastHit[] hits = Physics.RaycastAll(transform.position, transform.forward, 20.0F);
        foreach (RaycastHit hit in hits)
        {
            PRINCESS.Fight.FightTarget target = hit.transform.GetComponent<PRINCESS.Fight.FightTarget>();
            
            if (target == null) continue;
            if (!GetComponent<PRINCESS.Fight.Fighter>().ShouldAttack(target.gameObject)) continue;

            
            // GetComponent<PRINCESS.Fight.Fighter>().Attack(target.gameObject);
            PRINCESS.Core.Health targetHealth = target.GetComponent<PRINCESS.Core.Health>();
            if (targetHealth == null) return;
            targetHealth.CauseDamage(10f);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Coin"))
        {
            collision.gameObject.SetActive(false);
            GetComponent<Sounds>().PlayEatCoin();

            Destroy(collision.gameObject);
            // Add point
            currentCoinCount++;
            CoinController.GainCoin(1);
        }
        else if (collision.gameObject.CompareTag("Diamond"))
        {
            collision.gameObject.SetActive(false);
            GetComponent<Sounds>().PlayEatDiamond();

            Destroy(collision.gameObject);
            // Add point
            currentDiamondCount++;
            DiamondController.GainDiamond(1);
        }
    }

    // void OnCollisionExit(Collision collision)
    // {
    //     Debug.Log("Exited");
    //     if (collision.gameObject.CompareTag("Plane"))
    //     {
    //         isGrounded = false;
    //     }
    // }

}
