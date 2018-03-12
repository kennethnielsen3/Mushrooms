using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticVars : MonoBehaviour {
	
	public static int maxHealth = 5;
	public static int currentHealth = 5;
	public static int attackDamage = 1;
	public static Transform spawnPoint;
	public static GameObject player;
	public static bool grounded = false;
	public static bool ceiling = false;
	public static bool controlActive = true;
	public static bool alive = true;
	public static float jumpPower;
	public static float jumpPowerHold;
	public static float jumpTime = 0.5f;
	public static float moveSpeed;
	public static float LR;
	public static bool invincible = false;
	public static bool attacking = false;
	public static bool crouching = false;
    public static float knockBackTime;
	public enum ProjectileDirection {UP, LEFT, RIGHT, DOWN}
	public enum color {RED, YELLOW, GREEN, BLUE, MAGENTA, WHITE, BLACK}
}
