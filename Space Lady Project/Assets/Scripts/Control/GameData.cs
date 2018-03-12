using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour {
	public int health = 5;
	public float moveSpeed = 4;
	public float jumpPower = 6;
	public float jumpPowerHold = 6;
	public float jumpTime = 0.5f;
	public bool controlActive = true;
	public bool isGrounded = false;
	public GameObject player;
	public bool invincible = false;
    public float knockBackTime = 0.2f;

	void Awake()
	{
        StaticVars.maxHealth = health;
		StaticVars.moveSpeed = moveSpeed;
		StaticVars.jumpPower = jumpPower;
		StaticVars.jumpPowerHold = jumpPowerHold;
		StaticVars.jumpTime = jumpTime;
		StaticVars.controlActive = controlActive;
		StaticVars.grounded = isGrounded;
		StaticVars.player = player;
		StaticVars.invincible = invincible;
		StaticVars.knockBackTime = knockBackTime;

    }
	void Update()
	{
		StaticVars.moveSpeed = moveSpeed;
		StaticVars.jumpPower = jumpPower;
		StaticVars.jumpPowerHold = jumpPowerHold;
		StaticVars.jumpTime = jumpTime;
    }
}