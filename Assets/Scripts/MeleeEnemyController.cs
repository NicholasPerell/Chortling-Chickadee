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

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        count = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, player.transform.position);

        if (playerDistance <= vision)
        {
            if (!player.GetComponent<PlayerStatsController>().beingAttacked || player.GetComponent<PlayerStatsController>().attackingEnemy == gameObject)
            {

                anim.SetBool("Moving", true);

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
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/Enemy/crabsfx/crab swim");
                }
                else
                {
                    transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, runSpeed * Time.deltaTime);
                    //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/Enemy/crabsfx/melee crab/crab aggro");
                }
            }
        }
        else
        {

            anim.SetBool("Moving", false);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerStatsController>().ChangeHealth(-dmg);
            Vector2 relativeVelocity = transform.position - col.gameObject.transform.position;
            col.GetComponent<Rigidbody2D>().velocity = -relativeVelocity.normalized * 10;

            anim.SetTrigger("Attack");
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/Enemy/crabsfx/melee crab/crab punch");
        }
    }

    public void takeDamage(float damageTaken)
    {
        anim.SetTrigger("Hurt");
        hp -= damageTaken;
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/Enemy/crabsfx/melee crab/crab hurt");
    }

    public void healDamage(float damageHealed)
    {
        hp += damageHealed;
    }
}
