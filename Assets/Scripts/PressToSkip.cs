using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PressToSkip : MonoBehaviour
{
    [SerializeField]
    int sceneId;

    PlayerControls controls;
    private void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Pause.performed += _ => UnityEngine.SceneManagement.SceneManager.LoadScene(sceneId);
    }

    private void OnEnable()
    {
        controls.Player.Enable();
        controls.Player.Pause.Enable();
    }

    private void OnDisable()
    {
        controls.Player.Disable();
        controls.Player.Pause.Disable();
    }
}
