using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour 
{
	public int WaypointsAmount
	{
		get { return transform.childCount; }
	}

	public Vector3 GetWaypointPosition(int index)
	{
		return transform.GetChild (index).position;
	}

	public void OnDrawGizmos()
	{
		Gizmos.color = Color.green;

		for (int i = 0; i < WaypointsAmount; i++) 
		{
			int nextIndex = (i + 1) % WaypointsAmount;
			Vector3 origin = GetWaypointPosition (i);
			Vector3 dest = GetWaypointPosition (nextIndex);
			Gizmos.DrawLine (origin, dest);
		}
	}
}