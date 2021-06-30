using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootInDirection : MonoBehaviour
{
    [SerializeField] float angle = -90;
    [SerializeField] float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, angle);
        GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * speed;
    }
}
