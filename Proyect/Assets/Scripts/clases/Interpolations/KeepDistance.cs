using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistance : MonoBehaviour 
{
	[SerializeField] Transform target;
	[SerializeField] float speed;
	[SerializeField] float distanceMin;
	[SerializeField] float distanceMax;

	void Update()
	{
		Vector3 diff = target.position - transform.position;
		Vector3 dir = diff.normalized;
		float dist = diff.magnitude;

		if (dist < distanceMin) 
		{
			transform.position -= dir * speed * Time.deltaTime;
		} 

		if (dist > distanceMax) 
		{
			transform.position += dir * speed * Time.deltaTime;
		}
	}
}