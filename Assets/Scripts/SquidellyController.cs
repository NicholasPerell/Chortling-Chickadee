using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidellyController : MonoBehaviour
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
    private Transform projectile;

    private GameObject player;
    private float playerDistance;
    private float circleAngle;
    private bool clockwise = false;
    private bool colliding = false;
    private float count;

    // make state machine it go speed kachow
    // if (hp <= 2) -> else (state machine)

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerDistance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (hp <= 2)
        {
            Debug.Log("Running Away");
            transform.position = Vector2.MoveTowards(gameObject.transform.position, -1 * player.transform.position, runSpeed * Time.deltaTime);
        }
        else if (playerDistance <= circleRadius)
        {
            Debug.Log("Attacking Player");

            if (clockwise)
            {
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
                Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
                count = 0;
            }
        }
        else if (playerDistance <= vision)
        {
            Debug.Log("Moving To Player");
            transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, runSpeed * Time.deltaTime);
        }
        else
            Debug.Log("Not Attacking Player");
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            colliding = true;
            clockwise = !clockwise;
            Debug.Log("Enter");
        }
    }

    void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
        {
            colliding = false;
            Debug.Log("Exit");
        }
    }

    public void takeDamage(float damageTaken)
    {
        hp -= damageTaken;
    }
}
