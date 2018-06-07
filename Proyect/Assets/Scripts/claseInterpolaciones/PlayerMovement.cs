using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour 
{
	[SerializeField] float speed;

	void Update()
	{
		var movDir = Vector3.zero;
		movDir += transform.forward * Input.GetAxis ("Vertical");
		movDir += transform.right * Input.GetAxis ("Horizontal");
		movDir = Vector3.ClampMagnitude (movDir, 1);

		var mov = Vector3.zero;
		mov += movDir * speed;
		//TODO: Agregar fuerza de salto y gravedad
		transform.position += mov * Time.deltaTime;
	}
}