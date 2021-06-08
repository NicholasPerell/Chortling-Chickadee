using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class PlayerDialogueContinuer : MonoBehaviour
{

    PlayerControls controls;
    GameManager gameManager;
    DialogueUI dialogueUI;

    public bool active = false;

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Interact.performed += _ => AttemptContinue();
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
        dialogueUI = GameObject.FindObjectOfType<DialogueUI>();
    }

    // Update is called once per frame
    void AttemptContinue()
    {
        if(gameManager.mode == GameMode.INTERACTING && active)
            dialogueUI.MarkLineComplete();
    }

    public void SetOpening(bool a)
    {
        active = a;
    }
}
