using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikePillarScript : MonoBehaviour {

	public Transform spike;
	public Transform position1;
	public Transform position2;
	Vector3 newPosition;
	float speed;
	public float stabSpeed = 10;
	public float resetSpeed = 3;
	public float resetTime = 2;
	public float reActivateTime = 2;
	public bool active = true;
	public bool move = true;
	void Start()
	{
		spike.position = position1.position;
		newPosition = position1.position;
	}
	public void Activate() 
	{
		if(active == true)
		{
			newPosition = position2.position;
			speed = stabSpeed;
			active = false;
			Invoke("Reset",resetTime);
		}
    }
	void Reset()
	{
		newPosition = position1.position;
		speed = resetSpeed;
		Invoke("ReActivate",reActivateTime);
	}
	void ReActivate()
	{
		active = true;
	}
	
	IEnumerator Move(){
        while(move == true)
        {
		spike.position = Vector3.Lerp(spike.position, newPosition, speed * Time.deltaTime);
		yield return new WaitForFixedUpdate();
		}
	}

}
