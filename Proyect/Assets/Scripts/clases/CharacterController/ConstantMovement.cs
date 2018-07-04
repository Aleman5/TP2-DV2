using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantMovement : MonoBehaviour 
{
	[SerializeField] float speed;

	public float Speed 
	{
		get { return speed; }
		set { speed = value; }
	}

	void Update () 
	{
		transform.position += transform.forward * speed * Time.deltaTime;	
	}
}