using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBoom : MonoBehaviour
{
    public float length;
    public Transform cameraTransform;

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit))
        {
            cameraTransform.position = hit.point;
        }
        else
        {
            cameraTransform.position = transform.position + transform.forward * length;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * length);
    }
}
