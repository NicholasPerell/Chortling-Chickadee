using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class JumpThroughPlatformController : MonoBehaviour
{
    public float timeFlipped = 0.1f;
    float time;

    GameObject player;
    PlayerControls controls;
    PlatformEffector2D plat;

    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        plat = GetComponent<PlatformEffector2D>();

        controls = new PlayerControls();
        controls.Player.Drop.performed += _ => AttemptDrop();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Drop.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
        controls.Player.Drop.Disable();
    }

    private void Update()
    {
        if (time > 0)
        {
            time -= Time.deltaTime;
            if (time <= 0)
            {
                plat.rotationalOffset = 0;
            }
        }
    }

    private void AttemptDrop()
    {
        PlayerMovementController ply = player.GetComponent<PlayerMovementController>();
        bool onDoppable = Physics2D.OverlapCircle(ply.groundCheck.position, ply.checkRadius, ply.dropLayer) != null;
        if (onDoppable)
        {
            time = timeFlipped;
            plat.rotationalOffset = 180;
        }
    }
}
