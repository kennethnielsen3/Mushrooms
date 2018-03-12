using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerZoneSpike : MonoBehaviour {
	public GameObject zone;
	public SpikePillarScript spike;
	//public float resetWaitTime = 2;
	void OnTriggerEnter (Collider other) {
			//zone.SetActive(false);
			spike.Activate();
			//Invoke("ZoneReset", resetWaitTime);
    }
	void ZoneReset()
	{
		zone.SetActive(true);
	}
	
}
