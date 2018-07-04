using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterFireRate : MonoBehaviour 
{
	float cooldown;

	[SerializeField] GameObject prefab;
	[SerializeField] float fireRate = 1;

	void Update()
	{
		cooldown -= Time.deltaTime;

		if (Input.GetButton ("Fire1") && cooldown <= 0) 
		{
			Instantiate (prefab, transform.position, transform.rotation);
			cooldown = fireRate;
		}
	}
}