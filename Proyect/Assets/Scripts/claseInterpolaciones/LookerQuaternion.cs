using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookerQuaternion : MonoBehaviour 
{
	[SerializeField] Transform target;

	void Update()
	{
		Vector3 dir = Vector3.Normalize (target.position - transform.position);
		transform.rotation = Quaternion.LookRotation (dir);
	}
}