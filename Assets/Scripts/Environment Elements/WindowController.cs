using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField] float forceToBreak;
    [SerializeField] GameObject shatterPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Debug.Log(collision.relativeVelocity.magnitude);
    //    if (collision.gameObject.name == "Grabbable Object" && collision.relativeVelocity.magnitude > forceToBreak)
    //    {
    //        Instantiate(shatterPrefab, transform.position, transform.rotation, transform.parent);
    //        Destroy(this.gameObject);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Grabbable Object")
        {
            Instantiate(shatterPrefab, transform.position, transform.rotation, transform.parent);
            Destroy(this.gameObject);
            FMODUnity.RuntimeManager.PlayOneShot("event:/Puzzle Complete");
        }
    }
}
