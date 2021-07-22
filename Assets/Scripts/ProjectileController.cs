using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private float damage = 1.0f;
    [SerializeField]
    private LayerMask diesContactingWith;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            other.GetComponent<PlayerStatsController>().ChangeHealth(-damage);
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/Enemy/crabsfx/ranged crab/range crab hit");
            Destroy(gameObject);
        }
        else if(other.name == "Shield Particles" || diesContactingWith == (diesContactingWith | (1 << other.gameObject.layer)))
        {
            Destroy(gameObject);
        }
    }
}
