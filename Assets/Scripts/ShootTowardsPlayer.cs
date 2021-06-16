using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTowardsPlayer : MonoBehaviour
{
    [SerializeField]
    private float projectileSpeed = 3f;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = (player.transform.position - transform.position).normalized * projectileSpeed;
    }
}
