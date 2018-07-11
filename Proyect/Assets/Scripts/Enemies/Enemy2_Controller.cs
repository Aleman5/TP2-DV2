using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2_Controller : MonoBehaviour
{
    Animator anim;
    LineRenderer line;
    float timeToAttack = 0.5f;
    float savedTime = Time.time;

    [SerializeField] Transform target;
    [SerializeField] float speed;
    [SerializeField] float distanceMin;
    [SerializeField] float distanceMax;

    [SerializeField] float rangeAttack;
    [SerializeField] LayerMask layerHit;
    [SerializeField] ParticleSystem hitParticles;

    void Awake()
    {
        anim = GetComponent<Animator>();
        line = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            Vector3 diff = target.position - transform.position;
            diff.y = 0;
            Vector3 dir = diff.normalized;
            float dist = diff.magnitude;

            if (anim.GetCurrentAnimatorStateInfo(0).IsName("WalkBackwards"))
            {
                if(Time.time - savedTime >= 5)
                    anim.SetBool("MovingBack", false);

                transform.position -= dir * speed * (2/3) * Time.deltaTime;
            }
            else if (dist < distanceMax)
            {
                transform.forward = dir;

                if (dist < distanceMin)
                {
                    if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
                    {
                        anim.SetTrigger("Attack");
                        anim.SetBool("Moving", false);

                        line.SetPosition(0, target.transform.position);

                        StartCoroutine(RayAttack(transform.forward, timeToAttack));
                    }
                }
                else if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
                {
                    transform.position += dir * speed * Time.deltaTime;
                    anim.SetBool("Moving", true);
                }
            }
            else
                anim.SetBool("Moving", false); // Not moving
        }
    }

    IEnumerator RayAttack(Vector3 dir, float delayTime)
    {
        line.enabled = true;
        yield return new WaitForSeconds(delayTime);
        line.enabled = false;

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 1.4f, dir, out hit, rangeAttack, layerHit))
        {
            // Setting Death animation as true
            Animator anim = hit.transform.GetComponent<Animator>();
            anim.SetBool("Death", true);

            // Disabling Character Controller of Player
            CharacterController cc = hit.transform.GetComponent<CharacterController>();
            cc.enabled = !cc.enabled;

            // Instantiating the particles from where the enemy was hitted
            Instantiate(hitParticles, hit.point, hit.transform.rotation);
        }

        savedTime = Time.time;
    }
}
