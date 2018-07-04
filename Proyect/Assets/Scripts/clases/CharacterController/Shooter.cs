using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour 
{
	[SerializeField] GameObject prefab;

	void Update()
	{
		if (Input.GetButtonDown ("Fire1")) 
		{
			Instantiate (prefab, transform.position, transform.rotation);
		}
	}
}