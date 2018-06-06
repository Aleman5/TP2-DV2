using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacterController : MonoBehaviour 
{
	float verticalSpeed;
    private Animator anim;
    CharacterController cc;

    [SerializeField] float maxSpeed;
	[SerializeField] float gravity;
	[SerializeField] float jumpForce;
	//[SerializeField] GameObject particlePrefab;

	void Awake()
	{
        anim = GetComponent<Animator>();
		cc = GetComponent<CharacterController> ();
	}

	void Update()
	{
		//Aplico la gravedad a la fuerza vertical
		verticalSpeed -= gravity * Time.deltaTime;

		//Calculo y aplico la fuerza de movimiento en base al input y la fuerza vertical
		Vector3 mov = new Vector3 (0, 0, 0);
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            mov += transform.forward * Input.GetAxis("Vertical") * (maxSpeed/2);
            mov += transform.right * Input.GetAxis("Horizontal") * (maxSpeed/2);
        }
        else
        {
            mov += transform.forward * Input.GetAxis("Vertical") * maxSpeed;
            mov += transform.right * Input.GetAxis("Horizontal") * maxSpeed;
        }

        mov += Vector3.up * verticalSpeed;
		cc.Move (mov * Time.deltaTime);

        mov.y = 0;
        anim.SetFloat("Velocity", mov.magnitude / maxSpeed);

		//Si luego de moverme toque el suelo reseteo la fuerza vertical a 0.
		if (cc.isGrounded) 
		{
			if (Input.GetButton ("Jump")) 
				verticalSpeed = jumpForce;
			else 
				verticalSpeed = 0;
		}

		/*if ((cc.collisionFlags & CollisionFlags.Above) != 0) 
		{
			print ("above");
		}

		if ((cc.collisionFlags & CollisionFlags.Below) != 0) 
		{
			print ("below");
		}

		if ((cc.collisionFlags & CollisionFlags.Sides) != 0) 
		{
			print ("sides");
		}*/
	}

	/*void OnControllerColliderHit(ControllerColliderHit hit)
	{
		//Instantiate (particlePrefab, hit.point, Quaternion.identity);
	}*/
}