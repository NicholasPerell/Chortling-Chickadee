using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameMode
{
    NONE,
    PLAYING,
    INTERACTING,
    PAUSE
}

public class GameManager : MonoBehaviour
{
    public GameMode mode = GameMode.PLAYING;
    GameMode previousMode = GameMode.PLAYING;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
