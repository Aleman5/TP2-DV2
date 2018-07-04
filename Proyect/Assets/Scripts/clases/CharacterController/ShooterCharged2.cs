using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCharged2 : MonoBehaviour 
{
	float pressStartTime;

	[SerializeField] GameObject prefab;
	[SerializeField] float minSpeed;
	[SerializeField] float maxSpeed;
	[SerializeField] float maxTime;

	void Update()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			//Guardo el momento en el que presione la tecla
			pressStartTime = Time.time;
		}

		if (Input.GetButtonUp ("Fire1")) 
		{
			//Calculo el tiempo que mantuve presionando comparando la hora actual
			//con la que era cuando presione la tecla
			float pressedTime = Time.time - pressStartTime;

			//Esto se explica en ShooterCharged.cs
			GameObject go = Instantiate (prefab, transform.position, transform.rotation);
			ConstantMovement goMov = go.GetComponent<ConstantMovement> ();
			float timePerc = Mathf.Clamp01 (pressedTime / maxTime);
			goMov.Speed = minSpeed + (maxSpeed - minSpeed) * timePerc;
		}
	}
}