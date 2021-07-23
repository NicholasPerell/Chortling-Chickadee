using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [Header("Screens")]
    public GameObject start;
    public GameObject options;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        ToStart();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void CloseScreens()
    {
        start.SetActive(false);
        options.SetActive(false);
    }

    public void ToStart()
    {
        CloseScreens();
        start.SetActive(true);
    }

    public void ToOptions()
    {
        CloseScreens();
        options.SetActive(true);
    }

    public void ToCredits()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(5);
    }

    public void LoadGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(2);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
