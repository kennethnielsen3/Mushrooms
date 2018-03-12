using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeControl : MonoBehaviour {
	public int health = 3;
	public GameObject damageParticles;
	public GameObject deathParticles;
	private Transform enemy;
	private bool alive = true;
	private bool invincible = false;
	private float invincibleCounter;

	void Start () 
	{	
		enemy = GetComponent<Transform>();
	}
	
	void Update()
	{
		if(health <= 0 && alive)
		{
			gameObject.SetActive(false);
			alive = false;
			Instantiate(deathParticles, enemy.transform.position, enemy.transform.rotation);
		}
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

	void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag("Attack") && !invincible)
        {
			invincibleCounter = 0.2f;
			invincible = true;
			health -= StaticVars.attackDamage;
            Instantiate(damageParticles, enemy.transform.position, enemy.transform.rotation);
        }
    }
}
