using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PauseManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;

    PlayerControls controls;

    private void Awake()
    {
        pausePanel.SetActive(false);
        controls = new PlayerControls();
        controls.Player.Pause.performed += _ => ManageEsc();
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

    public void ManageEsc()
    {
        switch(GameManager.mode)
        {
            case GameMode.DEATH:
                break;
            case GameMode.PLAYING:
            case GameMode.INTERACTING:
                PauseGame();
                break;
            case GameMode.PAUSE:
                ResumeGame();
                break;
        }
    }

    void PauseGame()
    {
        pausePanel.SetActive(true);
        GameManager.SetMode(GameMode.PAUSE);
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        GameManager.RevertMode();
    }
}
