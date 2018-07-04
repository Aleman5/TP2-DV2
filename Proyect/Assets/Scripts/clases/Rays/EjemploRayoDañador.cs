using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploRayoDañador : MonoBehaviour
{
    public float daño;
    public float distanciaMaxima;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hitInfo;
            bool hit = Physics.Raycast(transform.position, transform.forward, 
                                       out hitInfo, distanciaMaxima);

            if(hit)
            {
                Vida vida = hitInfo.collider.GetComponent<Vida>();
                if(vida != null)
                {
                    float porcentajeCercania = 1 - hitInfo.distance / distanciaMaxima;
                    vida.cantidad -= daño * porcentajeCercania;
                }
            }
        }
    }
}