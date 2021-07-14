using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeEnemyController : MonoBehaviour
{
    public float hp = 12f;
    public float dmg = 3f;
    public float vision = 5f;

    [SerializeField]
    private float runSpeed = 1f;
    [SerializeField]
    private float attackRange = 3f;
    [SerializeField]
    private float attackSpeed = 3f;

    private GameObject player;
    private float playerDistance;
    private float count;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        count = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, player.transform.position);

        if (!player.GetComponent<PlayerStatsController>().beingAttacked || player.GetComponent<PlayerStatsController>().attackingEnemy == gameObject)
        {
            player.GetComponent<PlayerStatsController>().beingAttacked = true;
            player.GetComponent<PlayerStatsController>().attackingEnemy = gameObject;

            if (hp <= 0)
            {
                Destroy(gameObject);
                player.GetComponent<PlayerStatsController>().beingAttacked = false;
                player.GetComponent<PlayerStatsController>().attackingEnemy = null;
            }
            else if (playerDistance <= attackRange)
            {
                transform.position = new Vector3(player.transform.position.x + attackRange * Mathf.Cos(attackSpeed * count), transform.position.y, transform.position.z);
                count += Time.deltaTime;
            }
            else if (playerDistance <= vision)
                transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, runSpeed * Time.deltaTime);
        }
    }

    public void takeDamage(float damageTaken)
    {
        hp -= damageTaken;
    }

    public void healDamage(float damageHealed)
    {
        hp += damageHealed;
    }
}
