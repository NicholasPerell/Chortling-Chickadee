using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardousSurface : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] Vector2 bounce;

    public static PassNothing AcidHarm;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStatsController>().ChangeHealth(-damage);
            collision.gameObject.GetComponent<PlayerStatsController>().Stun();
            collision.rigidbody.velocity = -(new Vector2(collision.relativeVelocity.normalized.x * bounce.x, collision.relativeVelocity.normalized.y * bounce.y));

            if(name.Contains("Toxic Stream"))
            {
                AcidHarm?.Invoke();
            }
        }
    }
}
