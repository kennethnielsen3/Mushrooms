using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour {

	public Text health;
	public Text grounded;
	public Text controlActive;
	public Text jumpPower;
	public Text moveSpeed;

	void Update()
	{
		grounded.text = "grounded : " + StaticVars.grounded.ToString();
		controlActive.text = "controlActive : " + StaticVars.controlActive.ToString();
		jumpPower.text = "jumpPower : " + StaticVars.jumpPower.ToString();
		moveSpeed.text = "moveSpeed : " + StaticVars.moveSpeed.ToString();
	}

}