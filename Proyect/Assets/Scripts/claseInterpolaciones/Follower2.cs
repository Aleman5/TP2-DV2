using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower2 : MonoBehaviour 
{
	[SerializeField] Transform target;
	[SerializeField] float speed;

	void Update()
	{
		var diff = target.position - transform.position;
		var dir = diff.normalized;
		transform.position += dir * speed * Time.deltaTime;
	}
}