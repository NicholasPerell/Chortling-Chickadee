using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabSandParticleBar : MonoBehaviour
{
    public GameObject grabPoint;
    GameObject player;
    ParticleSystem ps;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        ParticleSystem.ShapeModule shape = ps.shape;

        transform.position = Vector3.Lerp(grabPoint.transform.position, player.transform.position, .5f);

        Vector3 bar = grabPoint.transform.position - player.transform.position;

        shape.scale = new Vector3(bar.magnitude, shape.scale.y, shape.scale.z);
        shape.rotation = new Vector3(0, 0, Vector3.SignedAngle(Vector3.right,bar,Vector3.forward));

        ParticleSystem.EmissionModule em = ps.emission;
        em.rateOverTime = 200 * shape.scale.x;
    }
}
