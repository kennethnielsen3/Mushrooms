using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealScript : MonoBehaviour {
	public int healAmount = 1;
    public GameObject healParticles;
    public bool deactivate = false;
    
    void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag("HurtBox") && StaticVars.alive)
        {
            HealthManager.HealPlayer(healAmount);
            Instantiate(healParticles, StaticVars.player.transform.position, StaticVars.player.transform.rotation);
            if(deactivate)
            {
                gameObject.SetActive(false);
            }
        }
    }
    
}
