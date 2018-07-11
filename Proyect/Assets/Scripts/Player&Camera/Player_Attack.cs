using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Attack : MonoBehaviour
{
    Animator anim;
    float timeToAttack = 0.5f;

    [SerializeField] float rangeAttack;
    [SerializeField] LayerMask layerHit;
    [SerializeField] ParticleSystem hitParticles;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Death"))
            if (Input.GetButtonDown("Fire1"))
            {
                anim.SetTrigger("Attack");
                StartCoroutine(RayAttack());
            }
    }

    IEnumerator RayAttack()
    {
        yield return new WaitForSeconds(timeToAttack);

        RaycastHit hit;
        if (Physics.Raycast(transform.position + Vector3.up * 1.4f, transform.forward, out hit, rangeAttack, layerHit))
        {
            // Setting Death animation as true
            Animator hitAnim = hit.transform.GetComponent<Animator>();
            hitAnim.SetBool("Death", true);

            // Disabling collider of the Enemy
            Collider hitColl = hit.transform.GetComponent<Collider>();
            hitColl.enabled = !hitColl.enabled;

            // Instantiating the particles from where the enemy was hitted
            Instantiate(hitParticles, hit.point, hit.transform.rotation);
        }
    }
}
