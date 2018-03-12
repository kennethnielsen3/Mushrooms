using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyScript : MonoBehaviour {
	public Transform obj;
	public Transform position1;
	public Transform position2;
	Vector3 newPosition;
    //Quaternion myRotate;
	Vector3 rotValue;
	public string currentState;
	public float speed = 5;
	public float resetwait = 5;
	public bool move = true;
	void Start()
	{
		currentState = "position 1";
		newPosition = position1.position;
		obj.position = position1.position;
		StartCoroutine(Move());
        MovePosition();
	}
	public void MovePosition() {
        switch(currentState)
		{
			case "position 1":
				newPosition = position2.position;
				currentState = "position 2";
                rotValue.y = 180;
				break;
			
			case "position 2":
				newPosition = position1.position;
				currentState = "position 1";
                rotValue.y = 0;
				break;
		}
        //myRotate.eulerAngles = rotValue;
        //transform.rotation = myRotate;
		Invoke("MovePlat",resetwait);
		
    }
	 IEnumerator Move(){
        while(move == true)
        {
            obj.position = Vector3.MoveTowards(obj.position, newPosition, speed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }


















}



/*




	public Transform platform;
	public Transform position1;
	public Transform position2;
	Vector3 newPosition;
	public string currentState;
	public float speed = 5;
	public float resetwait = 5;
	public bool resetAfter = false;
	public bool move = true;
	void Start()
	{
		currentState = "position 1";
		platform.position = position1.position;
		newPosition = position1.position;
		StartCoroutine(Move());
	}
	public void MovePlat() {
        switch(currentState)
		{
			case "position 1":
				newPosition = position2.position;
				currentState = "position 2";
				break;
			
			case "position 2":
				newPosition = position1.position;
				currentState = "position 1";
				break;
		}
		if(resetAfter == true){
			Invoke("MovePlat",resetwait);
			resetAfter = false;
		}
    }
	 IEnumerator Move(){
        while(move == true)
        {
           platform.position = Vector3.MoveTowards(platform.position, newPosition, speed * Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }













	public float moveSpeed = 2;
    public Transform obj;
    public bool objMove = true;
    float speed;
    void Start () {
        StartCoroutine(Move());
    }

	Quaternion myRotate;
	Vector3 rotValue;
     IEnumerator Move ()
    {
        while(objMove == true)
        {
            speed = moveSpeed * Mathf.Cos (Time.time) * Time.deltaTime;
            platform.transform.Translate (speed,0,0);

            if(speed > 0 )
			rotValue.y = 0;

            if(speed < 0)
                rotValue.y = 180;

            myRotate.eulerAngles = rotValue;
            transform.rotation = myRotate;

            yield return new WaitForFixedUpdate();
        }
    }
























 */