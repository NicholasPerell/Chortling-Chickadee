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

    private GameObject player;
    private float playerDistance;
    private float circleAngle;
    private bool clockwise;

    // make state machine it go speed kachow
    // if (hp <= 2) -> else (state machine)

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
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
        }
        else if (playerDistance <= vision)
        {
            Debug.Log("Moving To Player");
            transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, runSpeed * Time.deltaTime);
        }
        else
            Debug.Log("Not Attacking Player");

        // circle player
        //transform.position = circleRadius * new Vector3(Mathf.Cos(Time.time * speed), Mathf.Sin(Time.time * speed), 0);
        // run away
        //transform.position = Vector2.MoveTowards(gameObject.transform.position, -1 * player.transform.position, speed * Time.deltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Wall")
            clockwise = !clockwise;
    }

    public void takeDamage(float damageTaken)
    {
        hp -= damageTaken;
    }
}
