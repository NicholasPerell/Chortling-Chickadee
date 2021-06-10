using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquidellyController : MonoBehaviour
{
    public float hp = 10f;
    public float dmg = 1f;
    public float vision = 5f;

    private GameObject player;
    private float playerDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(gameObject.transform.position, player.transform.position);

        if (playerDistance <= vision)
            Debug.Log("Attacking Player");
        else
            Debug.Log("Not Attacking Player");
    }
}
