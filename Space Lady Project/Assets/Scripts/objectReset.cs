using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectReset : MonoBehaviour {
	private Vector3 startPosition;
	private Vector3 startScale;
	private Quaternion startRotation;
	private Rigidbody2D rb;
	void Start () 
	{
		ResetCharacter.resetObjects += ResetObj;
		startPosition = transform.position;
		startScale = transform.localScale;
		startRotation = transform.rotation;
		if(GetComponent<Rigidbody2D>() != null)
		{
			rb = GetComponent<Rigidbody2D>();
		}
		
	}
	public void ResetObj()
	{
		transform.position = startPosition;
		transform.localScale = startScale;
		transform.rotation = startRotation;

		if(rb != null)
		{
			rb.velocity = Vector3.zero;
		}
	}
	

}
