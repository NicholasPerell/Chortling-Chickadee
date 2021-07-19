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
    PROJECTILE = 0,
    SHIELD = 1,
    GRAB = 2
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
    [SerializeField] float grabCostPerUnit;
    float[] costs = { 0.0f, 0.0f, 0.0f };

    //[Header("Collectables")]
    //[SerializeField] int sandDollars;
    //[SerializeField] List<Items> items;

    [Header("Collectables")]
    [SerializeField] public bool[] hasAbility = { true, true, true };
    bool[] inUse = { false, false, false};

    [Header("When Damaged")]
    [SerializeField] float timeStunned, timeInvulnerable;
    float invulnerabilityTimer;


    PlayerMovementController movement;
    SandAbilityManager abilMan;
    [SerializeField] Animator anim;

    bool empty;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        movement = GetComponent<PlayerMovementController>();
        abilMan = GetComponent<SandAbilityManager>();

        costs[0] = glassCost;
        costs[1] = shieldCost;
        costs[2] = grabCost;

        currentHealth = currentMaxHealth;
        currentSand = currentMaxSand;
        plannedSand = currentSand;
        secondsToRefillSand = 1 / secondsToRefillSand;

        empty = false;

        invulnerabilityTimer = 0;

        GameManager.ChangeGameMode += HandleGameMode;
    }

    // Update is called once per frame
    void Update()
    {
        if(invulnerabilityTimer > 0) invulnerabilityTimer -= Time.deltaTime;

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

        if(inUse[(int)SandAbilities.GRAB])
        {
            float dist = Vector3.Distance(transform.position, GameObject.FindObjectOfType<GrabbingSandAbility>().transform.position);
            plannedSand -= dist * grabCostPerUnit;
        }

        if(plannedSand <= 0)
        {
            DisableAllSand();
        }
    }

    void DisableAllSand()
    {
        empty = true;
        plannedSand = 0;
        abilMan.AttemptEndGrab();
        abilMan.AttemptEndThrow();
        abilMan.AttemptEndShield();
    }

    void RechargeSand()
    {
        currentSand = Mathf.Min(currentSand + Time.deltaTime * secondsToRefillSand, plannedSand);
        if(currentMaxSand == currentSand)
        {
            empty = false;
        }
    }

    public bool ChangeHealth(float delta)
    {
        if (delta < 0 && (movement.strafeTimer > movement.strafeCooldown || invulnerabilityTimer > 0)) return false;

        currentHealth += delta;
        if(currentHealth <= 0)
        {

            anim.SetBool("Dead",true);
            GameManager.TriggerGameOver();
            

            Destroy(this.movement);
            DisableAllSand();
            Destroy(this);
            return true;
        }
        else if (delta < 0)
        {
            anim.SetTrigger("Hurt");
            Stun();
            invulnerabilityTimer = timeInvulnerable;
        }

        currentHealth = Mathf.Min(currentHealth, currentMaxHealth);

        return true;
    }

    public bool ActivateSand(SandAbilities ability)
    {
        int index = (int)ability;

        if (empty || !hasAbility[index] || inUse[index] || currentSand - costs[index] < 0) return false;

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

    public void Stun()
    {
        movement.stunned = timeStunned;
    }

    void HandleGameMode(GameMode mode)
    {
        if (anim == null) return;

        switch(mode)
        {
            case GameMode.PLAYING:
            case GameMode.PAUSE:
                anim.updateMode = AnimatorUpdateMode.Normal;
                break;
            case GameMode.INTERACTING:
                anim.updateMode = AnimatorUpdateMode.UnscaledTime;
                break;
        }
    }
}
