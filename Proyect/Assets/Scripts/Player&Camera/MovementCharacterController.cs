using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCharacterController : MonoBehaviour 
{
    bool secondJump;

	float verticalSpeed;

    Animator anim;

    CharacterController cc;

    [SerializeField] float maxSpeed;
	[SerializeField] float gravity;
	[SerializeField] float jumpForce;
	//[SerializeField] GameObject particlePrefab;

	void Awake()
	{
        // Cursor Things
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        // Player Things
        secondJump = false;
        anim = GetComponent<Animator>();
		cc = GetComponent<CharacterController> ();
	}

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            //Aplico la gravedad a la fuerza vertical
            verticalSpeed -= gravity * Time.deltaTime;

            //Calculo y aplico la fuerza de movimiento en base al input y la fuerza vertical
            Vector3 mov = new Vector3(0, 0, 0);
            if (!Input.GetKey(KeyCode.LeftShift))
            {
                mov += transform.forward * Input.GetAxis("Vertical") * (maxSpeed / 2);
                mov += transform.right * Input.GetAxis("Horizontal") * (maxSpeed / 2);
            }
            else
            {
                mov += transform.forward * Input.GetAxis("Vertical") * maxSpeed;
                mov += transform.right * Input.GetAxis("Horizontal") * maxSpeed;
            }

            mov += Vector3.up * verticalSpeed;
            cc.Move(mov * Time.deltaTime);

            mov.y = 0;
            anim.SetFloat("Velocity", mov.magnitude / maxSpeed, 0.1f, Time.deltaTime);

            //Si luego de saltar toque el suelo reseteo la fuerza vertical a 0.
            if (cc.isGrounded)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    verticalSpeed = jumpForce;
                    anim.SetTrigger("Jump");
                    secondJump = true;
                }
                else
                    verticalSpeed = 0;
            }
            else if (secondJump)
                if (Input.GetButtonDown("Jump"))
                {
                    verticalSpeed = jumpForce;
                    anim.SetTrigger("Jump");
                    secondJump = false;
                }
        }
    }
}