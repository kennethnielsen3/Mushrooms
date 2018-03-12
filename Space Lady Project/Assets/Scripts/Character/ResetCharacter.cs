using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof (Rigidbody2D))]
public class ResetCharacter : MonoBehaviour {
    public Transform startPoint;
    //public GameObject healthBar;
    public GameObject deathParticles;
    private Rigidbody2D player;
    public Animator DeathScreenAnim;
    public GameObject DeathScreen;
    public static Action resetObjects;

    void Start()
    {
        StaticVars.spawnPoint = startPoint;
        player = GetComponent<Rigidbody2D>();
    }
 
    void Update()
    {
        if (StaticVars.currentHealth <= 0 && StaticVars.alive) 
        {
            Death();
        }
    }
    
    void Death () {
        StaticVars.controlActive = false;
        StaticVars.alive = false;
        StaticVars.invincible = true; 
        player.velocity = new Vector3(0, 0, 0);
        DeathScreen.SetActive(true);
        DeathScreenAnim.SetBool("Dead", true);
		//healthBar.SetActive(false);
        
        Instantiate(deathParticles, player.position, player.transform.rotation);
        
		Invoke ("Restart", 3);
    }

    void Restart () {
        resetObjects();
        DeathScreenAnim.SetBool("Dead", false);
        transform.position = StaticVars.spawnPoint.position;
		StaticVars.currentHealth = StaticVars.maxHealth;
        DeathScreen.SetActive(false);
        //healthBar.SetActive(true);
        StaticVars.controlActive = true;
        StaticVars.alive = true;
        StaticVars.invincible = false;
    }

}