using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagtiteDripController : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    public GameObject[] spawnPoints;
    [SerializeField] float spawnRateMin = .25f;
    [SerializeField] float spawnRateMax = .5f;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(spawnRateMin,spawnRateMax);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time < 0)
        {
            time = Random.Range(spawnRateMin,spawnRateMax);
            int index = Random.Range(0, spawnPoints.Length);
            Instantiate(projectilePrefab, spawnPoints[index].transform.position, Quaternion.identity);
        }

    }
}
