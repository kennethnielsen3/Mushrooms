using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour {
	public int damageAmount = 1;
    public float knockBackForce = 250;
    public GameObject damageParticles;
    public HealthManager health;
    
    void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag("HurtBox") && !StaticVars.invincible && StaticVars.alive)
        {
            StaticVars.invincible = true;
            Vector2 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
            health.DamagePlayer(damageAmount, hitDirection, knockBackForce);
            Instantiate(damageParticles, StaticVars.player.transform.position, StaticVars.player.transform.rotation);
            
        }
    }
}