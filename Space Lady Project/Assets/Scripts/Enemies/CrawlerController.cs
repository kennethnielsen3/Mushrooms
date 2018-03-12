using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerController : MonoBehaviour {
	public Rigidbody2D rbod;
	public Transform position1;
	public Transform position2;
	public Transform position3;
	public Transform position4;
	Vector2 newPosition;
	public string currentState;
	public float speed = 1;
	public bool move = true;
	public int health = 3;
	private bool alive = true;
	private bool invincible = false;
	private float invincibleCounter;
	public GameObject damageParticles;
	public GameObject deathParticles;

	void Start()
	{
		rbod = GetComponent<Rigidbody2D>();
		rbod.transform.position = position1.position;
		currentState = "position 1";
		newPosition = position2.position;
		StartCoroutine(Move());
	}
	void Update()
	{
		//Health check
		if(health <= 0 && alive)
		{
			gameObject.SetActive(false);
			alive = false;
			Instantiate(deathParticles, rbod.position, rbod.transform.rotation);
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
	}

	 IEnumerator Move(){
        while(move == true)
        {
			if(rbod.transform.position == position1.position)
			{
				currentState = "position 1";
			}
			if(rbod.transform.position == position2.position)
			{
				currentState = "position 2";
			}
			if(rbod.transform.position == position3.position)
			{
				currentState = "position 3";
			}
			if(rbod.transform.position == position4.position)
			{
				currentState = "position 4";
			}

			switch(currentState)
			{
				case "position 1":
					newPosition = position2.position;
					break;
				
				case "position 2":
					newPosition = position3.position;
					break;

				case "position 3":
					newPosition = position4.position;
					break;
				
				case "position 4":
					newPosition = position1.position;
					break;
			}

            rbod.transform.position = Vector2.MoveTowards(rbod.transform.position, newPosition, speed * Time.deltaTime);
			
            yield return new WaitForFixedUpdate();
        }
    }

	void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag("Attack") && !invincible)
        {
			invincibleCounter = 0.2f;
			invincible = true;
			rbod.velocity = new Vector3(0, 0, 0);
			move = false;
            Instantiate(damageParticles, rbod.transform.position, rbod.transform.rotation);
			health -= StaticVars.attackDamage;
			if(alive){ Invoke("Flinch", 0.3f); }
        }
    }

	public void Flinch()
    {
		if(alive)
		{
			move = true;
			StartCoroutine(Move());
		}
    } 
}
