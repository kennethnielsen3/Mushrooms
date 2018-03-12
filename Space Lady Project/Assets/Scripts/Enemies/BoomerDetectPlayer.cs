using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerDetectPlayer : MonoBehaviour {
	public BoomerController controler;
	void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag("Player") && controler.alive)
        {
			controler.ExplodeActivate();
        }
    }
}
