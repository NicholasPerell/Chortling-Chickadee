using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Ground Movement")]
    [SerializeField] float groundRunForce = 100;
    [SerializeField] float groundMaxRunSpeed = 2;
    [SerializeField] float groundLinearDrag = .1f;
    [SerializeField] float groundGravityScale = 3.0f;
    [SerializeField] float jumpForce = 400;
    [SerializeField] float velocityCut = 0.125f;

    [Header("Water Movement")]
    [SerializeField] float waterRunForce = 100;
    [SerializeField] float waterMaxRunSpeed = 2.5f;
    [SerializeField] float waterLinearDrag = .1f;
    [SerializeField] float waterGravityScale = .1f;

    [Header("Strafing")]
    [SerializeField] float strafeSpeed = 20;
    [SerializeField] float strafeLength = .5f;
    [SerializeField] public float strafeCooldown = 1.0f;

    [HideInInspector]
    public float strafeTimer = 0;

    [Header("Physics Checks")]
    [SerializeField] public float checkRadius = 0.1f;
    public Transform groundCheck;
    public Transform[] leftWallCheck;
    public Transform[] rightWallCheck;
    [SerializeField] LayerMask groundLayer;
    [SerializeField] LayerMask wallLayer;
    [SerializeField] public LayerMask dropLayer;
    [SerializeField] LayerMask waterLayer;
    bool onLand = true;
    bool onGround = false;
    bool walledLeft = false;
    bool walledRight = false;

    PlayerControls controls;
    Rigidbody2D rb;
    Vector2 inputDir;

    [Header("Animation")]
    public Transform appearanceModel;
    Animator anim;

    //[HideInInspector] 
    public float stunned;

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        controls = new PlayerControls();

        controls.Player.Jump.performed += _ => AttemptJump();
        controls.Player.EndJump.performed += _ => AttemptEndJump();

        controls.Player.Strafe.performed += _ => AttemptStrafe();

        controls.Player.MovementInput.performed += ctx => UpdateDirInput(ctx.ReadValue<Vector2>());
        controls.Player.MovementInput.started += ctx => UpdateDirInput(ctx.ReadValue<Vector2>());
        controls.Player.MovementInput.canceled += ctx => UpdateDirInput(ctx.ReadValue<Vector2>());
    }

    // Start is called before the first frame update
    void Start()
    {
        stunned = 0;
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = groundGravityScale;
        rb.drag = groundLinearDrag;
        onLand = true;
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.MovementInput.Enable();
        controls.Player.Jump.Enable();
        controls.Player.Strafe.Enable();
    }


    private void OnDisable()
    {
        controls.Player.Disable();
        controls.Player.MovementInput.Disable();
        controls.Player.Jump.Disable();
        controls.Player.Strafe.Disable();
    }

    void Update()
    {
    }

    void FixedUpdate()
    {
        if (strafeTimer > 0) strafeTimer -= Time.fixedDeltaTime;

        CheckForGround();
        CheckForWalls(ref walledLeft,ref leftWallCheck);
        CheckForWalls(ref walledRight,ref rightWallCheck);

        //Prevent pushing into the walls/getting stuck
        if(strafeTimer < strafeCooldown)
        {
            if(walledLeft)
            {
                inputDir.x = Mathf.Max(0, inputDir.x);
            }
            else if(walledRight)
            {
                inputDir.x = Mathf.Min(0, inputDir.x);
            }
        }

        if (stunned > 0)
        {
            stunned -= Time.fixedDeltaTime;
        }
        else if(strafeTimer > strafeCooldown)
        {
            StrafeMovement();
        }
        else if (onLand)
        {
            GroundMovement();
        }
        else
        {
            WaterMovement();
        }

        SendAnimationData();
    }

    void CheckForGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer) != null;

        bool prevLand = onLand;
        onLand = Physics2D.OverlapCircle(groundCheck.position, checkRadius, waterLayer) == null;
        
        if(onLand && !prevLand)
        {
            rb.velocity = new Vector2(rb.velocity.x,0);
            rb.AddForce(new Vector2(0, jumpForce * 2/3));

            rb.gravityScale = groundGravityScale;
            rb.drag = groundLinearDrag;
        }
        else if (!onLand && prevLand)
        {
            rb.gravityScale = waterGravityScale;
            rb.drag = waterLinearDrag;
        }
    }

    void CheckForWalls(ref bool result, ref Transform[] checks)
    {
        result = false;
        foreach(Transform t in checks)
        {
            result = result || Physics2D.OverlapCircle(t.position, checkRadius, wallLayer) != null;
        }
    }

    void UpdateDirInput(Vector2 dir)
    {
        if (strafeTimer < strafeCooldown)
        {
            inputDir = dir;
        }
    }

    void StrafeMovement()
    {
        if (onLand)
        {
            rb.velocity = new Vector2(inputDir.x * strafeSpeed, 0.0f);
        }
        else
        {
            rb.velocity = inputDir * strafeSpeed;
        }
    }

    void WaterMovement()
    {
        if (Mathf.Abs(inputDir.y) > .1f)
        {
            rb.AddForce(inputDir * waterRunForce);
        }
        else
        {
            rb.AddForce(new Vector2(inputDir.x * waterRunForce, 0.0f));
        }

        rb.velocity = Vector2.ClampMagnitude(rb.velocity, waterMaxRunSpeed);
    }

    void GroundMovement()
    {
        rb.AddForce(new Vector2(inputDir.x * groundRunForce, 0.0f));

        rb.velocity = new Vector2(Mathf.Clamp(rb.velocity.x,-groundMaxRunSpeed, groundMaxRunSpeed), rb.velocity.y);
    }

    public void AttemptJump()
    {
        if (stunned > 0) return;

        if (onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce));
            onGround = false;
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/Player Movement/Jump/land jump");
        }
    }

    void AttemptEndJump()
    {
        if (stunned > 0) return;

        if(onLand && rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * velocityCut);
        }
    }

    public void AttemptStrafe()
    { 
        if (stunned > 0) return;

        if (strafeTimer <= 0)
        {
            strafeTimer = strafeLength + strafeCooldown;
        }
    }

    void SendAnimationData()
    {
        anim.SetFloat("Speed",Mathf.Abs(rb.velocity.x));
        anim.SetBool("OnLand",onLand);
        anim.SetBool("Strafing", strafeTimer > strafeCooldown);

        float buffering = 0.5f;

        if (rb.velocity.x > buffering)
            appearanceModel.localScale = new Vector3(1, 1, 1);
        else if (rb.velocity.x < -buffering)
            appearanceModel.localScale = new Vector3(-1, 1, 1);
    }
}
