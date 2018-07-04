using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Looker : MonoBehaviour 
{
	[SerializeField] Transform target;

	void Update()
	{
		var diff = target.position - transform.position;
		diff.y = 0;
		var dir = diff.normalized;

		transform.forward = dir;
	}
}