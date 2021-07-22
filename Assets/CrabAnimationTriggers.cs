using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void PassNothing();

public class CrabAnimationTriggers : MonoBehaviour
{

    public static event PassNothing CrabDeath;

    private GameObject player;
    [SerializeField]
    private GameObject projectile;
    [SerializeField]
    private Transform projSpawn;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    public void ThrowUrchin()
    {
        Instantiate(projectile, projSpawn.position, Quaternion.identity);
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/Enemy/crabsfx/ranged crab/ranged crab throw");
    }

    public void CheckCircleDead()
    {
        if (transform.parent.parent.gameObject.GetComponent<CircleEnemyController>().hp <= 0)
        {
            CrabDeath?.Invoke();
            player.GetComponent<PlayerStatsController>().beingAttacked = false;
            player.GetComponent<PlayerStatsController>().attackingEnemy = null;
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/Enemy/crabsfx/ranged crab/ranged crab death");
            Destroy(transform.parent.parent.gameObject);
        }
    }

    public void CheckMeleeDead()
    {
        if (transform.parent.parent.gameObject.GetComponent<MeleeEnemyController>().hp <= 0)
        {
            CrabDeath?.Invoke();
            player.GetComponent<PlayerStatsController>().beingAttacked = false;
            player.GetComponent<PlayerStatsController>().attackingEnemy = null;
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/Enemy/crabsfx/melee crab/crab death");
            Destroy(transform.parent.parent.gameObject);
        }
    }
}
