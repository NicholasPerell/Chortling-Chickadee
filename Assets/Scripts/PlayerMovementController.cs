using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    public float runSpeed = 2;
    public float strafeSpeed = 20;
    public float jumpForce = 400;

    public float timeToDoubleTap = .5f;
    public float strafeLength = .5f;
    public float strafeCooldown = 1.0f;
    float tapTime = 0;
    float strafeTimer = 0;

    PlayerControls controls;

    public bool onLand = true;
    public bool onGround = false;

    public Vector2 inputDir;

    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;

    Rigidbody2D rb;

    void Awake()
    {
        controls = new PlayerControls();

        controls.Player.Strafe.performed += _ => AttemptStrafe();
        controls.Player.Jump.performed += _ => AttemptJump();

       // controls.Player.MovementInput.performed += ctx => UpdateDirInput(ctx.ReadValue<Vector2>());
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    // Update is called once per frame
    void Update()
    {
        InputCheck();
        if (tapTime > 0) tapTime -= Time.deltaTime;
        if (strafeTimer > 0) strafeTimer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        CheckForGround();

        if (onLand)
        {
            GroundMovement();
        }
        else
        {
            WaterMovement();
        }
    }

    void CheckForGround()
    {
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer) != null;
    }

    void InputCheck()
    {
       inputDir = controls.Player.MovementInput.ReadValue<Vector2>();
    }

    void UpdateDirInput(Vector2 dir)
    {
        if(strafeTimer < strafeCooldown)
        inputDir = dir;
    }

    void WaterMovement()
    {
        rb.gravityScale = .5f;

        float speed = runSpeed;
        if (strafeTimer > strafeCooldown)
            speed = strafeSpeed;

        if(Mathf.Abs(inputDir.y) > .1f) rb.velocity = inputDir * speed;
        else rb.velocity = new Vector2(inputDir.x * speed, rb.velocity.y);
    }

    void GroundMovement()
    {
        rb.gravityScale = 1.0f;

        float speed = runSpeed;
        if (strafeTimer > strafeCooldown)
            speed = strafeSpeed;

        rb.velocity = new Vector2(inputDir.x * speed, rb.velocity.y);
    }

    public void AttemptJump()
    {
        if (onGround)
        {
            rb.AddForce(new Vector2(0, jumpForce));
            onGround = false;
        }
    }

    public void AttemptStrafe()
    {
        if (tapTime > 0 && strafeTimer <= 0)
        {
            strafeTimer = strafeLength + strafeCooldown;
            tapTime = 0;
            Debug.Log("stafe");
        }
        else
        {
            tapTime = timeToDoubleTap;
            Debug.Log("click detect");
        }
    }
}
