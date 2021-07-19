using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class EarningController : MonoBehaviour
{
    [SerializeField] SandAbilities ability;
    [SerializeField] float sandEarnt;

    PlayerStatsController ply;

    private void Start()
    {
        name = "SandProjectileEarn";
        ply = GameObject.FindObjectOfType<PlayerStatsController>();
        if (ply.hasAbility[(int)ability])
        {
            Destroy(this.gameObject);
        }
    }

    [YarnCommand("Bestow")]
    public void BestowAbility()
    {
        ply.currentMaxSand = ply.currentMaxSand + sandEarnt;
        ply.hasAbility[(int)ability] = true;

        Destroy(this.gameObject);
    }
}
