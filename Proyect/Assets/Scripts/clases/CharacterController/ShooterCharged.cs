using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCharged : MonoBehaviour 
{
	float pressedTime;

	[SerializeField] GameObject prefab;
	[SerializeField] float minSpeed;
	[SerializeField] float maxSpeed;
	[SerializeField] float maxTime;

	void Update()
	{
		if (Input.GetButton ("Fire1")) 
		{
			//Cuento el tiempo que mantuve presionada la tecla
			pressedTime += Time.deltaTime;
		}

		if (Input.GetButtonUp ("Fire1")) 
		{
			//Instancio la bala y obtengo su componente de movimiento para modificar la velocidad
			GameObject go = Instantiate (prefab, transform.position, transform.rotation);
			ConstantMovement goMov = go.GetComponent<ConstantMovement> ();

			//Divido el tiempo que mantuve presionada la tecla del maximo tiempo para
			//obtener el porcentaje que la mantuve presionada (limitado entre 0..1)
			float timePerc = Mathf.Clamp01 (pressedTime / maxTime);

			//La velocidad de la bala va a ser entre la minima y la maxima segun
			//cuanto tiempo mantuve presionada la tecla
			goMov.Speed = minSpeed + (maxSpeed - minSpeed) * timePerc;

			//Reseteo el contador de tiempo para la siguiente bala
			pressedTime = 0;
		}
	}
}