using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    [SerializeField] float range;
    [SerializeField] LayerMask layerHit;
    [SerializeField] ParticleSystem hitParticles;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, range, layerHit))
            {
                Debug.Log("Attack!");
                Animator anim = hit.transform.GetComponent<Animator>();
                anim.SetBool("Death", true);

                hitParticles.transform.position = hit.point;
                hitParticles.Play();
            }
        }
    }
}
