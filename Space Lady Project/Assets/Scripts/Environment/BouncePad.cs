using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BouncePad : MonoBehaviour {

	public static Action<float> Bounce;
	public float power = 2;

	public void OnTriggerEnter()
	{
		Bounce(power);
	}
}
