using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjemploSeleccionMovimiento : MonoBehaviour
{
    public Vector3 targetPos;
    public float speed;
    public Camera selectionCamera;

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = selectionCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if(Physics.Raycast(ray, out hitInfo))
            {
                targetPos = hitInfo.point;
            }
        }

        Vector3 dir = Vector3.Normalize(targetPos - transform.position);
        transform.position += dir * speed * Time.deltaTime;
    }
}