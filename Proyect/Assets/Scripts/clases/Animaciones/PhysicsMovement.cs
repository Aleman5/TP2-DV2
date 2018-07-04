using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsMovement : MonoBehaviour 
{
	private Rigidbody rb;

	[SerializeField] float maxSpeed;

	public float MaxSpeed 
	{
		get { return maxSpeed; }
	}

	private void Awake()
	{
		rb = GetComponent<Rigidbody> ();
	}

	private void Update()
	{
		Vector3 movFwd = transform.forward * Input.GetAxis ("Vertical");
		Vector3 movRight = transform.right * Input.GetAxis ("Horizontal");
		float speedMultiplier = Input.GetKey (KeyCode.LeftShift) ? 1 : 0.5f;
		rb.velocity = (movFwd + movRight) * maxSpeed * speedMultiplier;
	}
}