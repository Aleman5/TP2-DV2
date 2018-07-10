using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIndirectLight : MonoBehaviour 
{
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Alpha1)) 
		{
			GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", Color.red);
			DynamicGI.SetEmissive (GetComponent<MeshRenderer> (), Color.red);
		}

		if (Input.GetKeyDown (KeyCode.Alpha2)) 
		{
			GetComponent<MeshRenderer> ().material.SetColor ("_EmissionColor", Color.green);
			DynamicGI.SetEmissive (GetComponent<MeshRenderer> (), Color.green);
		}
	}
}