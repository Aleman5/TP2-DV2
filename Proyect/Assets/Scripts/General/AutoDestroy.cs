using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField] float timeToDestroy;

    void Awake()
    {
        Invoke("DestroyMe", timeToDestroy);
    }

    void DestroyMe()
    {
        Destroy(gameObject);
    }
}
