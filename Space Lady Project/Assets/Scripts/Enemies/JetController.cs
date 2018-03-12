using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetController : MonoBehaviour {

	private Animator anim;
	public float offTime = 5;
	public float onTime = 5;
	public float delay = 1;
	void Start () 
	{
		anim = GetComponent<Animator>();
		Invoke ("Delay", delay);
	}

	void Delay()
	{
		StartCoroutine (JetRun());
	}
	
	public IEnumerator JetRun()
    {
		while (true)
		{
			anim.SetBool("On", false);

        	yield return new WaitForSeconds(offTime);
			
			anim.SetBool("On", true);

			yield return new WaitForSeconds(onTime);
		}
    }
}
