using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorExit : MonoBehaviour
{
    [Header("Interaction Range")]
    [SerializeField] Vector2 offset;
    [SerializeField] Vector2 size;

    [Header("UI")]
    [SerializeField] GameObject worldSpaceUI;

    PlayerControls controls;
    GameManager gameManager;

    bool inRange = false;
    bool active = false;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Interact.performed += _ => AttemptForInteraction();
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Interact.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
        controls.Player.Interact.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateIcon();
    }

    void FixedUpdate()
    {
        TestForInRange();
    }

    void TestForInRange()
    {
        inRange = Physics2D.OverlapBox(transform.position + new Vector3(offset.x, offset.y), size, 0, LayerMask.GetMask("Player")) != null;
    }

    void UpdateIcon()
    {
        worldSpaceUI.SetActive(!active && inRange && GameManager.mode == GameMode.PLAYING);
    }

    void AttemptForInteraction()
    {
        if (!active && inRange && GameManager.mode == GameMode.PLAYING)
        {
            GetComponent<LevelExit>().ChangeLevel(GameObject.FindGameObjectWithTag("Player"));
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/Non Diegetic/Door");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.Lerp(Color.green, Color.black, .5f);
        Gizmos.DrawWireCube(transform.position + new Vector3(offset.x, offset.y), size);
    }
}
