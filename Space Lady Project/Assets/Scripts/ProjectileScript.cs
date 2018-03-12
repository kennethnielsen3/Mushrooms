using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {
    public Rigidbody projectile;
    public Transform startPoint;
    public StaticVars.ProjectileDirection type;
    public float launchPower;
    public float fireInterval = 4;
    public float startOffset = 4;
    void Start(){
        Invoke("Fire", startOffset);
    }
    void Fire()
    {
        Rigidbody projectileInstance;
        projectileInstance = Instantiate(projectile, startPoint.position, startPoint.rotation)as Rigidbody;
        switch(type){
            case StaticVars.ProjectileDirection.UP:
               projectileInstance.AddForce(0,launchPower,0);
            break;

            case StaticVars.ProjectileDirection.DOWN:
                projectileInstance.AddForce(0,-launchPower,0);
            break;

            case StaticVars.ProjectileDirection.LEFT:
                projectileInstance.AddForce(-launchPower,0,0);
            break;

            case StaticVars.ProjectileDirection.RIGHT:
                projectileInstance.AddForce(launchPower,0,0);
            break;
        }
        Invoke("Fire", fireInterval);
    }
 
}