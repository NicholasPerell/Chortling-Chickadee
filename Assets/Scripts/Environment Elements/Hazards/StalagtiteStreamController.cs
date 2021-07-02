using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StalagtiteStreamController : MonoBehaviour
{
    [SerializeField] LayerMask raycastLayerMask;
    Vector3 anchor;
    Vector3 xOffset;


    // Start is called before the first frame update
    void Start()
    {
        anchor = transform.position;
        xOffset = new Vector3(transform.localScale.x * (transform.lossyScale.x / transform.localScale.x) / 2, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = transform.position;
        RaycastHit2D hitM = Physics2D.Raycast(anchor, Vector2.down, 300, raycastLayerMask);
        RaycastHit2D hitR = Physics2D.Raycast(anchor + xOffset, Vector2.down, 300, raycastLayerMask);
        RaycastHit2D hitL = Physics2D.Raycast(anchor - xOffset, Vector2.down, 300, raycastLayerMask);

        float scale = anchor.y - Mathf.Max(hitM.point.y, Mathf.Max(hitL.point.y, hitR.point.y));
        if (scale <= 0) scale = 0.01f;

        transform.localScale = new Vector3(transform.localScale.x, scale * (transform.localScale.y/ transform.lossyScale.y), transform.localScale.z);

        pos.y = anchor.y - scale / 2.0f;
        transform.position = pos;
    }
}
