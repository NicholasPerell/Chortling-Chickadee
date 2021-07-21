using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassSandController : MonoBehaviour
{
    [SerializeField] float damagePerSpeed;
    [SerializeField] LayerMask enemyMask;
    float radius;
    [SerializeField] bool prevTrigger = false;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        radius = GetComponent<CircleCollider2D>().radius;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        bool trigger = false;

        Collider2D collider = Physics2D.OverlapCircle(transform.position, radius, enemyMask);

        if(collider != null)
        {
            trigger = true;
            if (prevTrigger == false)
            {
                //TODO update this to the new general enemy component once the Squidelly controller is untangled
                collider.gameObject.GetComponent<CircleEnemyController>()?.takeDamage(damagePerSpeed * rb.velocity.magnitude);
                collider.gameObject.GetComponent<MeleeEnemyController>()?.takeDamage(damagePerSpeed * rb.velocity.magnitude);
            }
        }

        prevTrigger = trigger;
    }
}
