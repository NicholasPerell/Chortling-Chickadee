using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Items
{
    PUNKROCKALBUMCOVER
}

public enum SandAbilities
{
    PROJECTILE,
    GRAB,
    SHEILD,
    SCAPHANDRE
}

public class PlayerStatsController : MonoBehaviour
{
    [Header("Health")]
    [SerializeField] public float currentHealth;
    [SerializeField] public float currentMaxHealth;
    [SerializeField] public float endGameMaxHealth;

    [Header("Collectables")]
    [SerializeField] int sandDollars;
    [SerializeField] List<Items> items;

    [Header("Collectables")]
    [SerializeField] List<SandAbilities> abilities;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = currentMaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(float delta)
    {
        currentHealth += delta;
        if(currentHealth <= 0)
        {
            Debug.Log("Player Death");
            Destroy(this.gameObject);
        }
    }
}
