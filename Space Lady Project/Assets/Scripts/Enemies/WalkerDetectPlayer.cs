using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkerDetectPlayer : MonoBehaviour {
	public WalkerControl controler;
	void OnTriggerEnter2D (Collider2D other) 
    {
        if (other.CompareTag("Player"))
        {
            controler.hanging = false;
        }
    }
}
