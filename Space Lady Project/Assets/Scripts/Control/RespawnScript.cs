using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnScript : MonoBehaviour {
    public SpriteRenderer checkPoint;
    public Sprite checkPointOn;
    public Sprite checkPointOff;
    public Sprite checkPointIdle;
    public Transform spawnPoint;
    [SerializeField] private string state = "OFF";
    public RespawnScript[] points;
    void Check()
    {
        switch(state)
        {
            case "OFF":
               checkPoint.sprite = checkPointOff;
            break;

            case "ON":
               checkPoint.sprite = checkPointOn;
               StaticVars.spawnPoint = spawnPoint;
            break;

            case "IDLE":
               checkPoint.sprite = checkPointIdle;
            break;
        }
    }

    void OnTriggerEnter2D (Collider2D other) {
		StaticVars.spawnPoint = spawnPoint;
        state = "ON";
        Check();
        foreach(RespawnScript point in points){
            if(point.state == "ON")
            {
                point.state = "IDLE";
            }
            point.Check();
        }
    }
}