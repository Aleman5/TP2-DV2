using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityDetector : MonoBehaviour 
{
	[SerializeField] Transform target;
	[SerializeField] GameObject alarm;
	[SerializeField] float alarmDistance;

	void Update()
	{
		var diff = target.position - transform.position;
		var dist = diff.magnitude;
		var inRange = dist <= alarmDistance;
		alarm.SetActive (inRange);
	}
}