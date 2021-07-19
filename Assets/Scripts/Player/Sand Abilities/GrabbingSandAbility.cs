using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GrabbingSandAbility : MonoBehaviour
{
    [SerializeField] float grabRange;

    PlayerControls controls;

    DistanceJoint2D dist;

    bool useful = true;

    //private void Awake()
    //{
    //    controls = new PlayerControls();
    //    controls.Player.Grab.performed += _ => AttemptGrabAttach();
    //    controls.Player.EndGrab.performed += _ => AttemptEndAttach();
    //}

    //private void OnEnable()
    //{
    //    controls.Player.Enable();
    //    controls.Player.Grab.Enable();
    //    controls.Player.EndGrab.Enable();
    //}

    //private void OnDisable()
    //{
    //    controls.Player.Disable();
    //    controls.Player.Grab.Disable();
    //    controls.Player.EndGrab.Disable();
    //}

    private void Update()
    {
        if(useful)
            AttemptGrabAttach();
    }

    private void AttemptGrabAttach()
    {
        if (dist != null) return;

        Collider2D[] overlaps = Physics2D.OverlapCircleAll(transform.position, grabRange);
        foreach(Collider2D e in overlaps)
        {
            if(e.name == "Grabbable Object")
            {
                dist = e.GetComponent<DistanceJoint2D>();
                dist.enabled = true;
                dist.connectedBody = GetComponent<Rigidbody2D>();
                dist.distance = Vector3.Distance(transform.position,e.transform.position);
                break;
            }
        }
    }

    public void AttemptEndAttach()
    {
        if (dist != null)
        {
            dist.enabled = false;
        }
        useful = false;
    }
}
