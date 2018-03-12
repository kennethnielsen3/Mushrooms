using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEntity: MonoBehaviour {
	private Transform entity;
	public Transform follow;
	void Awake()
	{
		entity = GetComponent<Transform>();
	}
	void Update () 
	{
		entity.transform.position = follow.transform.position;
	}
}
