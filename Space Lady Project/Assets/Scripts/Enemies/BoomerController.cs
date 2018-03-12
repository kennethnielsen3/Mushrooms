using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerController : MonoBehaviour {
	public Transform rightPoint;
	public Transform leftPoint;
	public bool movingRight = false;
	public float moveSpeed;
	public float bloatTime = 1;
	public float explodeTime = 4;
	private Rigidbody2D rbod;
	private Animator Anim;
	private bool move = true;
	public GameObject explodeParticles;
	private Vector2 moveDirection;
	public bool alive = true;
	private bool spriteRight;
	private SpriteRenderer spriteR;

	void Start () 
	{
		rbod = GetComponent<Rigidbody2D>();
		Anim = GetComponent<Animator>();
		spriteR = GetComponent<SpriteRenderer>();
	}

	void Update () 
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
		}
		else if(!movingRight && move){
			rbod.velocity = new Vector3(-moveSpeed, rbod.velocity.y, 0);
		}

		//flip sprite
		if(rbod.velocity.x > 0)
		{
			spriteR.flipX = true;
		}
		if(rbod.velocity.x < 0)
		{
			spriteR.flipX = false;
		}
	}

	//Getting Hit
	void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag("Attack") && alive)
        {
			StartCoroutine(Explode());
        }
    }
	public void ExplodeActivate()
	{
		StartCoroutine(Explode());
	}
	public IEnumerator Explode()
	{
		alive = false;
		move = false;
		rbod.velocity = new Vector3(0, 0, 0);
		Anim.SetBool("Bloat", true);

		yield return new WaitForSeconds(bloatTime);

		Anim.SetBool("Explode", true);
		Instantiate(explodeParticles, rbod.transform.position, rbod.transform.rotation);

		yield return new WaitForSeconds(explodeTime);

		gameObject.SetActive(false);
	}
}
