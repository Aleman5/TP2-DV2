using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeCamController : MonoBehaviour 
{
	[SerializeField] Transform cameraAxis;
	[SerializeField] Transform graphics;
	[SerializeField] float rotSpeed;
	[SerializeField] float movSpeed;

	void Update()
	{
		float camRotY = Input.GetAxis ("Mouse X") * rotSpeed * Time.deltaTime;
		cameraAxis.Rotate (0, camRotY, 0);

		Vector3 mov = cameraAxis.forward * Input.GetAxis ("Vertical") * movSpeed;
		transform.position += mov * Time.deltaTime;

		if (mov.magnitude > 0.01f) 
		{
			Quaternion targetRot = Quaternion.LookRotation (mov.normalized);
			graphics.rotation = Quaternion.Lerp (graphics.rotation, targetRot, 0.1f);
		}
	}
}