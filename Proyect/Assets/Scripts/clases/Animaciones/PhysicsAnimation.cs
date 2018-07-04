using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsAnimation : MonoBehaviour 
{
	private PhysicsMovement mov;
	private Animator anim;
	private Rigidbody rb;

	private void Awake()
	{
		mov = GetComponent<PhysicsMovement> ();
		anim = GetComponent<Animator> ();
		rb = GetComponent<Rigidbody> ();
	}

	private void Update()
	{
		//Creo una copia de la velocidad del rigidbody sin cotemplar el eje Y ya que
		//quiero obtener solo la velocidad horizontal. Obtengo la magnitud del vector
		//para saber la velocidad y la divido de la maxima para normalizarla (0..1).
		Vector3 horizontalVelocity = new Vector3 (rb.velocity.x, 0, rb.velocity.z);
		float normalizedVelocity = horizontalVelocity.magnitude / mov.MaxSpeed;

		//Le paso la velocidad horizontal normalizada al animator y la velocidad en Y
		//sin normalizar (ya que no hace falta normalizarla).
		anim.SetFloat ("HorizontalVelocity", normalizedVelocity, 0.2f, Time.deltaTime);
		anim.SetFloat ("VerticalVelocity", rb.velocity.y, 0.2f, Time.deltaTime);
	}
}