using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public enum GameMode
{
    NONE,
    PLAYING,
    INTERACTING,
    PAUSE,
    DEATH
}

public delegate void PassGameMode(GameMode mode);

public class GameManager : MonoBehaviour
{
    [SerializeField] float timeToFadeToGameOver = 1.0f;
    [SerializeField] Image blackScreen;

    public static GameMode mode = GameMode.PLAYING;
    static GameMode previousMode = GameMode.PLAYING;

    public static GameManager instance;

    public static event PassGameMode ChangeGameMode;

    public GameMode disMode;
    public GameMode disPreviousMode;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        //mode = GameMode.PLAYING;
        //previousMode = GameMode.PLAYING;
        //Time.timeScale = 1;
    }

    private void Update()
    {
        disMode = mode;
        disPreviousMode = previousMode;
    }

    public static void SetMode(int mode)
    {
        SetMode((GameMode)mode);
    }

    public static void SetMode(GameMode newMode)
    {
        if(mode != GameMode.PAUSE)
        previousMode = mode;
        mode = newMode;

        switch(newMode)
        {
            case GameMode.PAUSE:
            case GameMode.INTERACTING:
                Time.timeScale = 0;
                break;
            case GameMode.PLAYING:
                Time.timeScale = 1;
                break;
        }

        ChangeGameMode?.Invoke(newMode);
    }

    public static void RevertMode()
    {
        SetMode(previousMode);
    }

    public static void TriggerGameOver()
    {
        SetMode(GameMode.DEATH);
        instance.StartCoroutine(nameof(FadeToBlackDeath));
    }

    public static void QuitLevel()
    {
        SceneManager.LoadScene(1);
    }

    IEnumerator FadeToBlackDeath()
    {
        //TODO trigger stinger here
        blackScreen.enabled = true;
        blackScreen.DOFade(1, timeToFadeToGameOver);
        yield return new WaitForSeconds(timeToFadeToGameOver);
        SceneManager.LoadScene("g-death_screen");
    }
}
