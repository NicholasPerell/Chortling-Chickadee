using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovementController : MonoBehaviour
{
    [Header("Run/Jumping")]
    [SerializeField] float runSpeed = 2;
    [SerializeField] float jumpForce = 400;

    [Header("Strafing")]
    [SerializeField] float strafeSpeed = 20;
    [SerializeField] float timeToDoubleTap = .5f;
    [SerializeField] float strafeLength = .5f;
    [SerializeField] public float strafeCooldown = 1.0f;

    Dictionary<InputControl,float> tapTime;
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

    private void Awake()
    {
        anim = GetComponentInChildren<Animator>();
        controls = new PlayerControls();

        controls.Player.Jump.performed += _ => AttemptJump();

        controls.Player.Strafe.performed += ctx => AttemptStrafe(ctx.control);

        controls.Player.MovementInput.performed += ctx => UpdateDirInput(ctx.ReadValue<Vector2>());
        controls.Player.MovementInput.started += ctx => UpdateDirInput(ctx.ReadValue<Vector2>());
        controls.Player.MovementInput.canceled += ctx => UpdateDirInput(ctx.ReadValue<Vector2>());
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tapTime = new Dictionary<InputControl, float>();
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
        //InputCheck();
        if(tapTime.Count > 0)
        foreach (InputControl e in new ArrayList(tapTime.Keys))
        {
            if (tapTime[e] > 0) tapTime[e] -= Time.deltaTime;
        }
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

        if (onLand)
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
            //strafeTimer = Mathf.Min(strafeTimer, strafeCooldown);
            rb.velocity = new Vector2(rb.velocity.x,0);
            rb.AddForce(new Vector2(0, jumpForce * 2/3));
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
        Vector2 vel;

        rb.gravityScale = .5f;

        float speed = runSpeed;
        if (strafeTimer > strafeCooldown)
        {
            speed = strafeSpeed;
        }

        if(Mathf.Abs(inputDir.y) > .1f) vel = inputDir * speed;
        else vel = new Vector2(inputDir.x * speed, rb.velocity.y);

        rb.velocity = Vector2.Lerp(rb.velocity,vel,.2f);
    }

    void GroundMovement()
    {
        rb.gravityScale = 1.0f;

        //Make this a function that returns float
        float speed = runSpeed;
        if (strafeTimer > strafeCooldown)
        {
            speed = strafeSpeed;
        }

        rb.velocity = new Vector2(inputDir.x * speed, rb.velocity.y);
    }

    public void AttemptJump()
    {
        if (onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(new Vector2(0, jumpForce));
            onGround = false;
        }
    }

    public void AttemptStrafe(InputControl key)
    {
        if(!tapTime.ContainsKey(key))
        {
            tapTime.Add(key, 0);
        }

        float time = tapTime[key];

        if (time > 0 && strafeTimer <= 0)
        {
            strafeTimer = strafeLength + strafeCooldown;
            time = 0;
        }
        else
        {
            time = timeToDoubleTap;
        }

        tapTime[key] = time;
    }

    void SendAnimationData()
    {
        anim.SetFloat("Speed",Mathf.Abs(rb.velocity.x));
        anim.SetBool("OnLand",onLand);
        anim.SetBool("Strafing", strafeTimer > strafeCooldown);

        if (rb.velocity.x > 0)
            appearanceModel.localScale = new Vector3(1, 1, 1);
        else if (rb.velocity.x < 0)
            appearanceModel.localScale = new Vector3(-1, 1, 1);
    }
}
