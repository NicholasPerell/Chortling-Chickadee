using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SandAbilityManager : MonoBehaviour
{

    PlayerStatsController stats;

    PlayerControls controls;
    //public SandAbilities inUse;

    GameObject sandShield;
    GameObject sandTrail;

    void Awake()
    {
        sandShield = gameObject.GetComponentInChildren<FacePlayerMouse>().gameObject;
        sandTrail = GameObject.FindObjectOfType<SandMovement>().gameObject;

        controls = new PlayerControls();
        controls.Player.ThrowSand.performed += _ => AttemptThrow();
        controls.Player.ThrowSand.canceled += _ => sandTrail.GetComponent<SandMovement>().TurnBack();
        controls.Player.GrabSand.performed += _ => AttemptGrab();
        controls.Player.ShieldSand.performed += _ => AttemptShield();
        controls.Player.EndShieldSand.performed += _ => AttemptEndShield();
    }

    void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.ThrowSand.Enable();
        controls.Player.GrabSand.Enable();
        controls.Player.ShieldSand.Enable();
        controls.Player.EndShieldSand.Enable();
    }

    void OnDisable()
    {
        controls.Player.Disable();
        controls.Player.ThrowSand.Disable();
        controls.Player.GrabSand.Disable();
        controls.Player.ShieldSand.Disable();
        controls.Player.EndShieldSand.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        stats = GetComponent<PlayerStatsController>();
        sandShield.SetActive(false);
        sandTrail.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {

    }

    void AttemptThrow()
    {
        if(stats.ActivateSand(SandAbilities.PROJECTILE))
        {
            sandTrail.SetActive(true);
        }
    }
    void AttemptGrab()
    {

        if (stats.ActivateSand(SandAbilities.GRAB))
        {
            //inUse = SandAbilities.GRAB;
        }
    }

    void AttemptShield()
    {

        if (stats.ActivateSand(SandAbilities.SHIELD))
        {
            sandShield.SetActive(true);
        }
    }

    public void AttemptEndThrow()
    {
        if (stats.DeactivateSand(SandAbilities.PROJECTILE))
        {
            sandTrail.SetActive(false);
        }
    }

    void AttemptEndShield()
    {
        if (stats.DeactivateSand(SandAbilities.SHIELD))
        {
            sandShield.SetActive(false);
        }
    }
}
