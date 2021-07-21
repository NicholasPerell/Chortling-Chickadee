using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    [SerializeField] float forceToBreak;
    [SerializeField] GameObject shatterPrefab;
    FMOD.Studio.EventInstance snapshot;

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
            FMODUnity.RuntimeManager.PlayOneShot("event:/Stingers/Puzzle Complete");
            
            StartCoroutine(nameof(StingerController));
        Destroy(GetComponent<SpriteRenderer>());
        }
    }
    IEnumerator StingerController(){
         snapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Stingers");
            snapshot.start();
            yield return new WaitForSeconds(6);
             snapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            snapshot.release();
            Destroy(this.gameObject);
    }
}
