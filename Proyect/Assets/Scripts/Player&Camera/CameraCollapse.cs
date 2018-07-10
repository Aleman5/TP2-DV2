using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCollapse : MonoBehaviour
{
    public float length;
    public Transform cameraTransform;

    void Update()
    {
        RaycastHit hit;
        Vector3 dir = cameraTransform.position - transform.position;
        dir = dir.normalized;
        if(Physics.Raycast(transform.position, dir, out hit, length))
            cameraTransform.position = hit.point;
        else
            cameraTransform.position = transform.position + dir * length;
    }
}
