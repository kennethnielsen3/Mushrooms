using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
	private Transform entity;
	void Awake()
	{
		entity = GetComponent<Transform>();
	}
	void Update () 
	{
		entity.transform.position = StaticVars.player.transform.position;
	}
}
