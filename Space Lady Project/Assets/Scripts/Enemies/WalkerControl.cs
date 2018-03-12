using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerControl : MonoBehaviour {
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
	private bool spriteRight;
   	public bool hanging = false;
	private int state = 0;
	/*
		state 0: Idle
		state 1: Moving
		state 2: Flinch
	*/

	void Start () 
	{
		rbod = GetComponent<Rigidbody2D>();
		Anim = GetComponent<Animator>();
		StartCoroutine(Hang());
	}

	void Update () 
	{
		state = 0;

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

	}

	public IEnumerator Hang()
    {
		while(hanging)
		{
			rbod.velocity = new Vector3(0, 5, 0);
			move = false;
			yield return new WaitForFixedUpdate();
		}	
		while(!hanging)
		{
			yield return new WaitForSeconds(2);
			move = true;
		}	
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
		state = 2;
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
