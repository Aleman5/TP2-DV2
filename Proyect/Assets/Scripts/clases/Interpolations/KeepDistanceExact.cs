using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepDistanceExact : MonoBehaviour 
{
	[SerializeField] Transform target;
	[SerializeField] float distance;
	[SerializeField] float speed;

	void Update()
	{
		//Calculo una posición que esté alejada del atarget
		Vector3 dirToMe = Vector3.Normalize (transform.position - target.position);
		Vector3 targetPos = target.position + dirToMe * distance;

		//Calculo la dirección hacia el target y con eso cuanto deberia moverme
		Vector3 dirToTarget = Vector3.Normalize (targetPos - transform.position);
		Vector3 movement = dirToTarget * speed * Time.deltaTime;

		//Calculo la distancia hacia el target y limito el vector de movimiento
		//para que no sea mayor a dicha distancia, o sea, que no se pase
		float distToTarget = Vector3.Distance (targetPos, transform.position);
		movement = Vector3.ClampMagnitude (movement, distToTarget);

		//Aplico el movimiento luego de limitarlo
		transform.position += movement;
	}
}