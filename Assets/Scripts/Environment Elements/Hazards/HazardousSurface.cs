using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardousSurface : MonoBehaviour
{
    [SerializeField] float damage;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStatsController>().ChangeHealth(-damage);
            collision.rigidbody.velocity = -collision.relativeVelocity.normalized * 10;
        }
    }
}
