using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    [SerializeField]
    private float projectileSpeed = 3f;

    private GameObject player;
    private GameObject circleEnemy;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        circleEnemy = GameObject.Find("CircleEnemy");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(gameObject.transform.position, player.transform.position, projectileSpeed * Time.deltaTime);

        if (gameObject.transform.position == player.transform.position)
            Destroy(gameObject);
    }
}
