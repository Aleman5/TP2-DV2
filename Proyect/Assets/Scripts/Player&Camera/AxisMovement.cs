using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxisMovement : MonoBehaviour 
{
	float currentFwdMov;
	float currentRigMov;

	[SerializeField] float speed;

	void Update()
	{
		float targetFwdMov = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		float targetRigMov = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;

		//Interpolo la velocidad actual hacia la deseada a un 10% de la diferencia por frame
		currentFwdMov = Mathf.Lerp (currentFwdMov, targetFwdMov, 0.1f);
		currentRigMov = Mathf.Lerp (currentRigMov, targetRigMov, 0.1f);

		transform.position += 
			transform.forward * currentFwdMov + 
			transform.right * currentRigMov;
	}
}