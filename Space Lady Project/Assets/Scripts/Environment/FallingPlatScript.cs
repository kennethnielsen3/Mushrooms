using UnityEngine;
public class FallingPlatScript : MonoBehaviour {
    public GameObject obj;
    public GameObject plat;
    public Transform startPoint;
    public float waitTime = 1;
    public float disapearTime = 1;
    public float resetTime = 3;
    public bool doesRespawn = true;

    void OnTriggerEnter (Collider other) 
    {
        if (other.CompareTag ("Player")) 
        {
             Invoke("Away", waitTime);
        }
    }
    void Away () 
    {
        obj.SetActive(false);
        Invoke("Disable", disapearTime);
    }
    void Disable () 
    {
        plat.SetActive(false);
        if(doesRespawn == true){
            Invoke("Reset", resetTime);
        }
        
    }
     void Reset () 
    {
        obj.SetActive(true);
        plat.transform.position = startPoint.position;
        plat.SetActive(true);
    }
     

}
