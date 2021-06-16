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

    //[Header("Sand Meter")]
    //[SerializeField] public float currentSand;
    //[SerializeField] public float currentMaxSand;
    //[SerializeField] public float endGameMaxSand;
    //[SerializeField] public float secondsToRefillSand;

    [Header("Collectables")]
    [SerializeField] int sandDollars;
    [SerializeField] List<Items> items;

    [Header("Collectables")]
    [SerializeField] List<SandAbilities> abilities;

    PlayerMovementController movement;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovementController>();

        currentHealth = currentMaxHealth;
        //currentSand = currentMaxSand;
        //secondsToRefillSand = 1 / secondsToRefillSand;
    }

    // Update is called once per frame
    void Update()
    {
        RechargeSand();
    }

    void RechargeSand()
    {
        //currentSand = Mathf.Min(currentSand + Time.deltaTime * secondsToRefillSand, currentMaxSand);
    }

    public void ChangeHealth(float delta)
    {
        if (delta < 0 && movement.strafeTimer > movement.strafeCooldown) return;

        currentHealth += delta;
        if(currentHealth <= 0)
        {
            Debug.Log("Player Death");
            Destroy(this.gameObject);
        }
    }
}
