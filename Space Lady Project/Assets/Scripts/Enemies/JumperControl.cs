using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperControl : MonoBehaviour {

public Transform rightPoint;
	public Transform leftPoint;
	public bool movingRight = false;
	public float moveSpeed;
	private Rigidbody2D rbod;
	private Animator Anim;
	private bool move = true;
	public int health = 3;
	public float knockBackForce = 100;
	public GameObject damageParticles;
	public GameObject deathParticles;
	private Vector2 moveDirection;
	private bool alive = true;
	private bool invincible = false;
	private float invincibleCounter;
	public float StunTime = 0.8f;
	public float StunBounce = 1f;
	public float pounceForce = 300;
	public float pounceHeight = 1.5f;
	public bool pouncing = false;
	public GameObject detectBox;
	private Vector2 pounceDirection;
	float speed;
	private bool spriteRight;
	[SerializeField] private LayerMask m_WhatIsGround;
    private Transform m_GroundCheck;
    const float k_GroundedRadius = .2f;
	private bool grounded = false;
	private int state = 0;
	/*
		state 0: Idle
		state 1: Moving
		state 2: Crouch
	*/

	void Start () 
	{
		rbod = GetComponent<Rigidbody2D>();
		Anim = GetComponent<Animator>();
		m_GroundCheck = transform.Find("GroundCheck");
		
	}
	void FixedUpdate()
	{
		grounded = false;

		 // circlecast to check for ground
        Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius, m_WhatIsGround);

        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject){
				grounded = true;
			}
        }
	}

	void Update () 
	{
		if(!pouncing)
		{
			//Direction to move
			if(transform.position.x > rightPoint.position.x){
				movingRight = false;
			}
			if(transform.position.x < leftPoint.position.x){
				movingRight = true;
			}

			//Movement
			if(movingRight && move){
				rbod.velocity = new Vector3(moveSpeed, rbod.velocity.y, 0);
				state = 1;
			}
			else if(!movingRight && move){
				state = 1;
				rbod.velocity = new Vector3(-moveSpeed, rbod.velocity.y, 0);
			}
		}

		//Health check
		if(health <= 0 && alive)
		{
			gameObject.SetActive(false);
			alive = false;
			Instantiate(deathParticles, rbod.transform.position, rbod.transform.rotation);
		}
		//Invincible check
		if(invincibleCounter <= 0 && alive)
		{
			invincible = false;
		}
		if(invincibleCounter > 0)
		{
			invincible = true;
			invincibleCounter -= Time.deltaTime;
		}

		//flip sprite
		if(rbod.velocity.x > 0  && !spriteRight)
		{
			Flip();
		}
		if(rbod.velocity.x < 0  && spriteRight)
		{
			Flip();
		}

		Anim.SetInteger("State", state);
		Anim.SetBool("Grounded", grounded);

	}
	public void PounceActivate(Vector2 direction)
	{
		if(!pouncing)
		{
			pouncing = true;
			detectBox.SetActive(false);
			StartCoroutine(Pounce(direction));
		}
		
	}

	public IEnumerator Pounce(Vector2 direction)
    {
		//prepare
		move = false;
		rbod.velocity = new Vector3(0, 0, 0);
		state = 2;

		yield return new WaitForSeconds(0.5f);

		//pounce
		direction.y = pounceHeight;
		rbod.AddForce(direction * pounceForce);
		state = 3;

		yield return new WaitForSeconds(2.2f);
		
		move = true;
		pouncing = false;
		detectBox.SetActive(true);
    }        

	//Getting Hit
	void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag("Attack") && !invincible)
        {
			invincibleCounter = 0.2f;
			invincible = true;
			rbod.velocity = new Vector3(0, 0, 0);
            Vector2 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
			StartCoroutine(KnockBack(hitDirection));
            Instantiate(damageParticles, rbod.transform.position, rbod.transform.rotation);
			health -= StaticVars.attackDamage;
        }
    }
	public IEnumerator KnockBack(Vector2 direction)
    {
		move = false;
		rbod.velocity = new Vector3(0, 0, 0);
		direction.y = -StunBounce;
        rbod.AddForce(-direction * knockBackForce);

		yield return new WaitForSeconds(StunTime);

		move = true;
    } 
	private void Flip()
    {
        spriteRight = !spriteRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }      
}
