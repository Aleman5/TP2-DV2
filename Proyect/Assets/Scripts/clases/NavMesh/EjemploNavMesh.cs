using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EjemploNavMesh : MonoBehaviour 
{
	int currentWaypointIndex;
	NavMeshAgent nma;

	[SerializeField] Path path;

	void Awake()
	{
		nma = GetComponent<NavMeshAgent> ();
		nma.destination = path.GetWaypointPosition (currentWaypointIndex);
	}

	void Update()
	{
		if (!nma.pathPending && nma.remainingDistance < nma.stoppingDistance) 
		{
			currentWaypointIndex++;
			currentWaypointIndex %= path.WaypointsAmount;
			nma.destination = path.GetWaypointPosition (currentWaypointIndex);
		}
	}
}