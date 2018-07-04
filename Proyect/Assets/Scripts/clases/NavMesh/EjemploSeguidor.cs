using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EjemploSeguidor : MonoBehaviour 
{
	NavMeshAgent nma;
	Transform nearTarget;

	[SerializeField] Transform[] targets;
	[SerializeField] float time;
	[SerializeField] float distanceTreshold;

	void Awake()
	{
		nma = GetComponent<NavMeshAgent> ();
		InvokeRepeating ("Search", 0, time);
	}

	void Update()
	{
		Vector3 diff = nearTarget.position - nma.destination;
		if (diff.sqrMagnitude > distanceTreshold * distanceTreshold)
			nma.destination = nearTarget.position;
	}

	void Search()
	{
		float minDist = float.MaxValue;
		for (int i = 0; i < targets.Length; i++) 
		{
			float dist = Vector3.Distance (transform.position, targets [i].position);
			if (dist < minDist) 
			{
				minDist = dist;
				nearTarget = targets [i];
			}
		}
	}
}