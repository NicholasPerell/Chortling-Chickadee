using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode
{
    NONE,
    PLAYING,
    INTERACTING,
    PAUSE,
    DEATH
}

public class GameManager : MonoBehaviour
{
    [SerializeField] static float timeToFadeToGameOver = 1.0f;

    public GameMode mode = GameMode.PLAYING;
    GameMode previousMode = GameMode.PLAYING;

    public static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void SetMode(int mode)
    {
        SetMode((GameMode)mode);
    }

    public void SetMode(GameMode newMode)
    {
        previousMode = mode;
        mode = newMode;
    }

    public void RevertMode()
    {
        GameMode tmp = mode;
        mode = previousMode;
        previousMode = tmp;
    }

    public static void TriggerGameOver()
    {
        instance.StartCoroutine(nameof(FadeToBlack));
    }

    IEnumerator FadeToBlack()
    {
        //TODO trigger stinger here
        yield return new WaitForSeconds(timeToFadeToGameOver);
        SceneManager.LoadScene("g-death_screen");
    }
}
