using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeParticles : MonoBehaviour {
    public GameObject particles;
	public float time;
    void Awake()
    {
        Invoke("Create",time);
    }
	void Create()
	{
		Instantiate(particles, StaticVars.player.transform.position, StaticVars.player.transform.rotation);
	}
}
