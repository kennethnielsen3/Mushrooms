using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumperDetectPlayer : MonoBehaviour {
	public JumperControl controler;
	void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag("Player") && !controler.pouncing)
        {
            Vector2 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;
			controler.PounceActivate(hitDirection);
        }
    }
}
