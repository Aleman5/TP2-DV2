using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterFireRate2 : MonoBehaviour 
{
	float lastFireTime;

	[SerializeField] GameObject prefab;
	[SerializeField] float fireRate = 1;

	void Update()
	{
		float elapsedSinceFire = Time.time - lastFireTime;

		if (Input.GetButton ("Fire1") && elapsedSinceFire >= fireRate) 
		{
			Instantiate (prefab, transform.position, transform.rotation);
			lastFireTime = Time.time;
		}
	}
}