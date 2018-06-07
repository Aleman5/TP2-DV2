using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotate : MonoBehaviour 
{
	Quaternion targetRot;

	[SerializeField] float speed;
	[SerializeField] float changeTime;

	void Awake()
	{
		InvokeRepeating ("ChangeRotation", 0, changeTime);
	}

	void ChangeRotation()
	{
		targetRot = Quaternion.Euler (
			Random.Range(0f,360f),
			Random.Range(0f,360f),
			Random.Range(0f,360f));
	}

	void Update()
	{
		transform.rotation = Quaternion.RotateTowards (
			transform.rotation, targetRot, speed * Time.deltaTime);
	}
}