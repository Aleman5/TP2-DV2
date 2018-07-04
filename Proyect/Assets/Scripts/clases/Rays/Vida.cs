using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    public float cantidad;

    public void Update()
    {
        if(cantidad <= 0)
        {
            Destroy(gameObject);
        }
    }
}   