using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploRayo1 : MonoBehaviour
{
    public GameObject alarm;
    public float length;
    public LayerMask layers;

	void Update ()
    {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(transform.position, transform.forward, 
                                   out hitInfo, length, layers);
        alarm.SetActive(hit);

        if (hit)
        {
            Vida vida = hitInfo.collider.GetComponent<Vida>();
            if(vida != null)
            {
                print("La vida es " + vida.cantidad);
            }
            else
            {
                print("El objeto no tiene vida");
            }

            Debug.DrawRay(transform.position, transform.forward * hitInfo.distance);
        }
        else
        {
            print("El objeto no tiene vida");
            Debug.DrawRay(transform.position, transform.forward * length);
        }
	}
}
