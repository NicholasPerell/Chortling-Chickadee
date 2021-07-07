using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{

    public int id = -1;

    int total;
    // Start is called before the first frame update
    void Awake()
    {
        id = GameObject.FindObjectsOfType<LevelExit>().Length - 1;
        id -= GameObject.FindObjectOfType<LevelCatalog>().currentLvl.exits.Length;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Exit hit");
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Exit player");
            GameObject.FindObjectOfType<LevelCatalog>().ExitLevel(id, collision.gameObject.transform.position - transform.position);
        }
    }
}
