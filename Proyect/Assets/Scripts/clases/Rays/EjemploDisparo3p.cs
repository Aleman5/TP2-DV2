using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploDisparo3p : MonoBehaviour
{
    public Transform cameraTransform;
    public Transform gunTransform;

    public void Update()
    {
        RaycastHit hitInfo;
        bool hit = Physics.Raycast(cameraTransform.position, 
            cameraTransform.forward, out hitInfo);

        if(hit)
        {
            Debug.DrawLine(cameraTransform.position, hitInfo.point);

            Vector3 dir = Vector3.Normalize(hitInfo.point - gunTransform.position);
            hit = Physics.Raycast(gunTransform.position, dir, out hitInfo);

            if(hit)
            {
                print(hitInfo.collider.name);
                Debug.DrawLine(gunTransform.position, hitInfo.point);
            }
        }
    }
}
