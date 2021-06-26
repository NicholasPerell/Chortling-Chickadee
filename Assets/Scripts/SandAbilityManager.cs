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
    GameObject sandGrab;

    Animator anim;

    void Awake()
    {
        anim = GetComponentInChildren<Animator>();

        sandShield = gameObject.GetComponentInChildren<FacePlayerMouse>().gameObject;
        sandTrail = GameObject.Find("Glass Sand Ability Projectile");
        sandGrab = GameObject.FindObjectOfType<GrabbingSandAbility>().transform.parent.gameObject;

        controls = new PlayerControls();
        controls.Player.ThrowSand.performed += _ => AttemptThrow();
        controls.Player.ThrowSand.canceled += _ => sandTrail.GetComponent<SandMovement>().TurnBack();
        controls.Player.GrabSand.performed += _ => AttemptGrab();
        controls.Player.ShieldSand.performed += _ => AttemptShield();
        controls.Player.EndShieldSand.performed += _ => AttemptEndShield();
        controls.Player.GrabSand.performed += _ => AttemptGrab();
        controls.Player.GrabSand.canceled += _ => sandGrab.GetComponentInChildren<SandMovement>().TurnBack();
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
        sandGrab.SetActive(false);
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
            anim.SetTrigger("Attack");
        }
    }
    void AttemptGrab()
    {

        if (stats.ActivateSand(SandAbilities.GRAB))
        {
            sandGrab.SetActive(true);
            GameObject.FindObjectOfType<GrabbingSandAbility>().transform.position = transform.position;
            anim.SetTrigger("Attack");
        }
    }

    void AttemptShield()
    {

        if (stats.ActivateSand(SandAbilities.SHIELD))
        {
            sandShield.SetActive(true);
            anim.SetTrigger("Attack");
        }
    }

    public void AttemptEndThrow()
    {
        if (stats.DeactivateSand(SandAbilities.PROJECTILE))
        {
            sandTrail.SetActive(false);
        }
    }

    public void AttemptEndGrab()
    {
        if (stats.DeactivateSand(SandAbilities.GRAB))
        {
            sandGrab.SetActive(false);
        }
    }

    public void AttemptEndShield()
    {
        if (stats.DeactivateSand(SandAbilities.SHIELD))
        {
            sandShield.SetActive(false);
        }
    }
}
