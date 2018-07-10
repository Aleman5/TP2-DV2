using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1_Movement : MonoBehaviour
{
    Animator anim;

    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] float distanceMin;
    [SerializeField] float distanceMax;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        Vector3 diff = target.position - transform.position;
        Vector3 dir = diff.normalized;
        float dist = diff.magnitude;

        transform.forward = dir;
        
        if (dist < distanceMax)
        {
            if (dist < distanceMin)
            {
                if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
                {
                    anim.SetTrigger("Attack");
                    anim.SetBool("Moving", false);
                }
            }
            else if(!anim.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
            {
                transform.position += dir * speed * Time.deltaTime;
                anim.SetBool("Moving", true);
            }
        }
        else
            anim.SetBool("Moving", false); // Not moving
    }
}
