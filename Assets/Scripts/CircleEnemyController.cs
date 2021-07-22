using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemyController : MonoBehaviour
{
    public float hp = 10f;
    public float dmg = 1f;
    public float vision = 5f;

    [SerializeField]
    private float circleRadius = 3f;
    [SerializeField]
    private float circleSpeed = 3f;
    [SerializeField]
    private float runSpeed = 1f;
    [SerializeField]
    private float attackTimer = 2f;
    [SerializeField]
    private GameObject projectile;

    private GameObject player;
    private float playerDistance;
    private float circleAngle;
    private bool clockwise = false;
    private float count;

    private Animator anim;

    // make state machine it go speed kachow
    // if (hp <= 2) -> else (state machine)

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerDistance = Vector3.Distance(gameObject.transform.position, player.transform.position);


        if (playerDistance <= vision)
        {
            if (!player.GetComponent<PlayerStatsController>().beingAttacked || player.GetComponent<PlayerStatsController>().attackingEnemy == gameObject)
            {
                player.GetComponent<PlayerStatsController>().beingAttacked = true;
                player.GetComponent<PlayerStatsController>().attackingEnemy = gameObject;

                anim.SetBool("Moving", true);

                if (hp <= 0)
                {
                   
                }
                else if (hp <= 2)
                {
                    //Debug.Log("Running Away");
                    transform.position = Vector2.MoveTowards(gameObject.transform.position, -1 * player.transform.position, runSpeed * Time.deltaTime);
                }
                else if (playerDistance <= circleRadius)
                {
                    //Debug.Log("Attacking Player");
                    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/Enemy/crabsfx/crab swim");
                
                    if (clockwise)
                    {
                        // change to physics velocity
                        // keep rotatearound but add raycasting instead of collision
                        transform.RotateAround(player.transform.position, Vector3.forward, -(circleSpeed * Mathf.Rad2Deg) * Time.deltaTime);
                        transform.Rotate(0, 0, (circleSpeed * Mathf.Rad2Deg) * Time.deltaTime);
                    }
                    else
                    {
                        transform.RotateAround(player.transform.position, Vector3.forward, (circleSpeed * Mathf.Rad2Deg) * Time.deltaTime);
                        transform.Rotate(0, 0, -(circleSpeed * Mathf.Rad2Deg) * Time.deltaTime);
                    }

                    count += Time.deltaTime;
                    if (count >= attackTimer)
                    {
                        anim.SetTrigger("Attack");
                        
                        count = 0;
                    }
                }
                else
                {
                    //Debug.Log("Moving To Player");
                    transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, runSpeed * Time.deltaTime);
                    //FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/Enemy/crabsfx/ranged crab/ranged aggro");
                }
            }
        }
        else
        {
            //Debug.Log("Not Attacking Player");
            anim.SetBool("Moving", false);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            clockwise = !clockwise;
            //Debug.Log("Enter");
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            //Debug.Log("Exit");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerStatsController>().ChangeHealth(-dmg);
            Vector2 relativeVelocity = transform.position - col.gameObject.transform.position;
            col.GetComponent<Rigidbody2D>().velocity = -relativeVelocity.normalized * 10;
        }
    }

    public void takeDamage(float damageTaken)
    {
        anim.SetTrigger("Hurt");
        hp -= damageTaken;
        FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/Enemy/crabsfx/ranged crab/ranged crab hurt");
    }

    public void healDamage(float damageHealed)
    {
        hp += damageHealed;
    }

    public void ThrowUrchin()
    {
        Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
    }

    public void CheckDead()
    {
        if (hp <= 0)
        {
            player.GetComponent<PlayerStatsController>().beingAttacked = false;
            player.GetComponent<PlayerStatsController>().attackingEnemy = null;
            Destroy(gameObject);
        }
    }
}
