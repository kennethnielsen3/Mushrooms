using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour {
	public Animator Anim;
	public CharacterControler player;
	private float invincibleCounter = 0;
	public float invincibleTimeLimit = 2f;
	public GameObject HurtBox;
	void Start () 
	{
		StaticVars.currentHealth = StaticVars.maxHealth;
	}
	
	public void DamagePlayer (int damage, Vector2 direction,float knockBack) 
	{
		if(StaticVars.alive)
		{
			HurtBox.SetActive(false);
			player.KnockBack(direction, knockBack);
			invincibleCounter = invincibleTimeLimit;
			StaticVars.currentHealth -= damage;
		}
	}

	public static void HealPlayer (int heal) 
	{
		if(StaticVars.currentHealth < StaticVars.maxHealth)
		{
			StaticVars.currentHealth += heal;
		}
		else
		{
			StaticVars.currentHealth = StaticVars.maxHealth;
		}		
	}

	void Update() 
	{
		Anim.SetInteger("HP", StaticVars.currentHealth);

		if(invincibleCounter <= 0 && StaticVars.alive)
		{
			StaticVars.invincible = false;
			HurtBox.SetActive(true);
		}
		if(invincibleCounter > 0)
		{
			StaticVars.invincible = true;
			HurtBox.SetActive(false);
			invincibleCounter -= Time.deltaTime;
		}
	}

	
}
