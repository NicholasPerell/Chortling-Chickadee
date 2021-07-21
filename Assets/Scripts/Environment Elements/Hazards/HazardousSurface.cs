using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardousSurface : MonoBehaviour
{
    [SerializeField] float damage;
    [SerializeField] float bounce = 2;

    public static PassNothing AcidHarm;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStatsController>().ChangeHealth(-damage);
            collision.gameObject.GetComponent<PlayerStatsController>().Stun();
            collision.rigidbody.velocity = -collision.relativeVelocity.normalized * bounce;

            if(name.Contains("Toxic Stream"))
            {
                AcidHarm?.Invoke();
            }
        }
    }
}
