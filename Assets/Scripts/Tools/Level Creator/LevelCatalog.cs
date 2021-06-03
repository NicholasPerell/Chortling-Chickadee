using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct LevelIDKey
{
    public string name;
    public LevelData data;
}

[System.Serializable]
public struct LevelExitData
{
    public string nameExitsTo;
    public int exitNumber;
}

[System.Serializable]
public struct LevelData
{
    public Texture2D levelTexture;
    public Texture2D artTexture;
    public LevelExitData[] exits;
}

public class LevelCatalog : MonoBehaviour
{
    public string nameStartingLevel;
    public LevelIDKey[] levelCatalog;

    private Dictionary<string, LevelData> catalog;
    private LevelManager levelManager;

    [HideInInspector]
    public LevelData currentLvl;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        levelManager = GameObject.FindObjectOfType<LevelManager>();
        catalog = new Dictionary<string, LevelData>();
        foreach(LevelIDKey pair in levelCatalog)
        {
            catalog.Add(pair.name, pair.data);
        }
        GenerateArea(nameStartingLevel);
    }

    void GenerateArea(string name)
    {
        levelManager.LoadLevel(catalog[name].levelTexture, catalog[name].artTexture);
        currentLvl = catalog[name];
    }


    public void ExitLevel(int id)
    {
        LevelExitData levelExitData = currentLvl.exits[id];
        GenerateArea(levelExitData.nameExitsTo);

        foreach(LevelExit exit in GameObject.FindObjectsOfType<LevelExit>())
        {
            if(exit.id == levelExitData.exitNumber)
            {
                player.transform.position = exit.transform.position;
            }
        }
    }
}
