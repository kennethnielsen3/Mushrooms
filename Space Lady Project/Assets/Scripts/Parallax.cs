using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour {
	public Transform[] layers;
	private float[] distance;
	public float smoothing = 1f;
	private Transform cam;
	private Vector3 previousPosition;

	void Awake()
	{
		cam = Camera.main.transform;
	}

	void Start () 
	{
		previousPosition = cam.position;
		distance = new float[layers.Length];
		for (int i = 0; i < layers.Length; i++)
		{
			distance[i] = layers[i].position.z;
			//distance[i] = layers[i].position.z * -1;
		}
	}
	
	
	void Update () 
	{
		for (int i = 0; i < layers.Length; i++)
		{
			float parallaxX = (previousPosition.x - cam.position.x) * distance[i];
			float layerTargetPositionX = layers[i].position.x + parallaxX;

			float parallaxY = (previousPosition.y - cam.position.y) * distance[i];
			float layerTargetPositionY = layers[i].position.y + parallaxY;

			Vector3 layerTargetPosition = new Vector3(layerTargetPositionX, layerTargetPositionY, layers[i].position.z);

			layers[i].position = Vector3.Lerp(layers[i].position, layerTargetPosition, smoothing * Time.deltaTime);

		}
		previousPosition = cam.position;
		
	}
}

/*

for (int i = 0; i < layers.Length; i++)
		{
			float parallax = (previousPosition.x - cam.position.x) * distance[i];

			float layerTargetPositionX = layers[i].position.x + parallax;

			Vector3 layerTargetPosition = new Vector3(layerTargetPositionX, layers[i].position.y, layers[i].position.z);

			layers[i].position = Vector3.Lerp(layers[i].position, layerTargetPosition, smoothing * Time.deltaTime);
		}
		previousPosition = cam.position;







 */
