using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class EarningController : MonoBehaviour
{
    [SerializeField] SandAbilities ability;
    [SerializeField] float sandEarnt;

    [YarnCommand("Bestow")]
    public void BestowAbility()
    {
        PlayerStatsController ply = GameObject.FindObjectOfType<PlayerStatsController>();

        ply.currentMaxSand = ply.currentMaxSand + sandEarnt;
        ply.hasAbility[(int)ability] = true;

        Destroy(this.gameObject);
    }
}
