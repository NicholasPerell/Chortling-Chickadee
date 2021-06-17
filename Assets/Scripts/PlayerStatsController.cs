using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Items
{
    PUNKROCKALBUMCOVER
}

public enum SandAbilities
{
    NONE = -1,
    PROJECTILE,
    SHIELD,
    GRAB
}

public class PlayerStatsController : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] public float currentHealth;
    [SerializeField] public float currentMaxHealth;
    [SerializeField] public float endGameMaxHealth;

    [Header("Sand Meter")]
    [SerializeField] public float currentSand;
    [SerializeField] public float currentMaxSand;
    [SerializeField] public float endGameMaxSand;
    [SerializeField] public float secondsToRefillSand;
    [SerializeField] private float plannedSand;

    [Header("Sand Meter Costs")]
    //[SerializeField] float thrownCostPerDistance;
    [SerializeField] float glassCost;
    [SerializeField] float shieldCost;
    [SerializeField] float grabCost;
    float[] costs = { 0.0f, 0.0f, 0.0f };

    //[Header("Collectables")]
    //[SerializeField] int sandDollars;
    //[SerializeField] List<Items> items;

    [Header("Collectables")]
    [SerializeField] bool[] hasAbility = { true, true, true };
    bool[] inUse = { false, false, false};

    PlayerMovementController movement;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovementController>();

        costs[0] = glassCost;
        costs[1] = shieldCost;
        costs[2] = grabCost;

        currentHealth = currentMaxHealth;
        currentSand = currentMaxSand;
        plannedSand = currentSand;
        secondsToRefillSand = 1 / secondsToRefillSand;
    }

    // Update is called once per frame
    void Update()
    {
        DeterminePlannedSand();
        RechargeSand();
    }

    void DeterminePlannedSand()
    {
        plannedSand = currentMaxSand;
        for(int i = 0; i < costs.Length;i++)
        {
            if(inUse[i])
            {
                plannedSand -= costs[i];
            }
        }
    }

    void RechargeSand()
    {
        currentSand = Mathf.Min(currentSand + Time.deltaTime * secondsToRefillSand, plannedSand);
    }

    public bool ChangeHealth(float delta)
    {
        if (delta < 0 && movement.strafeTimer > movement.strafeCooldown) return false;

        currentHealth += delta;
        if(currentHealth <= 0)
        {
            Debug.Log("Player Death");
            //Destroy(this.gameObject);
        }
        return true;
    }

    public bool ActivateSand(SandAbilities ability)
    {
        int index = (int)ability;

        if (!hasAbility[index] || inUse[index] || currentSand - costs[index] < 0) return false;

        inUse[index] = true;
        currentSand -= costs[index];
        return true;
    }

    public bool DeactivateSand(SandAbilities ability)
    {
        int index = (int)ability;

        if (!hasAbility[index] || !inUse[index]) return false;

        inUse[index] = false;
        return true;
    }
}
