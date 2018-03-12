using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmoMarker : MonoBehaviour {
	public StaticVars.color color;
	//RED, YELLOW, GREEN, BLUE, MAGENTA, WHITE, BLACK	
	void OnDrawGizmosSelected() 
	{
		switch(color)
		{
			case StaticVars.color.RED:
				Gizmos.color = Color.red;
			break;

			case StaticVars.color.YELLOW:
				Gizmos.color = Color.yellow;
			break;

			case StaticVars.color.GREEN:
				Gizmos.color = Color.green;
			break;

			case StaticVars.color.BLUE:
				Gizmos.color = Color.blue;
			break;

			case StaticVars.color.MAGENTA:
				Gizmos.color = Color.magenta;
			break;

			case StaticVars.color.WHITE:
				Gizmos.color = Color.white;
			break;

			case StaticVars.color.BLACK:
				Gizmos.color = Color.black;
			break;
		}

        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
