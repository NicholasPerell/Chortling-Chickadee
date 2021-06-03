using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor;

[System.Serializable]
public class levelKey
{
    public artKey[] artKeys;
    public GameObject[] prefab;
}


[System.Serializable]
public class artKey
{
    public Color color;
    public TileBase tile;
}

public class LevelManager : MonoBehaviour
{
    [Header("Texture & Keys",order = 0)]
    [Space(10.0f,order = 1)]
    public Texture2D levelTexture;
    public Texture2D foregroundArtTexture;
    public Texture2D waterTexture;
    public Texture2D backgroundArtTexture;
    public levelKey levelMapDictionary;
    public artKey[] artMapDictionary;

    [Header("Tilemaps")]
    public Tilemap levelTilemap;
    public Tilemap foregroundArtTilemap;
    public Tilemap waterTilemap;
    public Tilemap backgroundArtTilemap;

    [Header("DEBUGGING")]
    public bool loadTileMapAsLevelOnStart = false;

    // Start is called before the first frame update
    void Start()
    {
        if(loadTileMapAsLevelOnStart)
        {
            Texture2D tmp = new Texture2D(levelTexture.width,levelTexture.height);
            SaveGridToTexture(ref levelTilemap, ref tmp, ref levelMapDictionary.artKeys);
            GenerateLevelFromTexture(ref tmp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadLevel()
    {
        LoadLevel(levelTexture, foregroundArtTexture, waterTexture, backgroundArtTexture);
    }

    public void LoadLevel(Texture2D lvl, Texture2D fg, Texture2D wat, Texture2D bg)
    {
        LoadTextureOntoGrid(ref foregroundArtTilemap, ref fg, ref artMapDictionary);
        LoadTextureOntoGrid(ref waterTilemap, ref wat, ref artMapDictionary);
        LoadTextureOntoGrid(ref backgroundArtTilemap, ref bg, ref artMapDictionary);
        GenerateLevelFromTexture(ref lvl);
    }

    void GenerateLevelFromTexture(ref Texture2D texture)
    {
        levelTilemap.ClearAllTiles();

        int childs = transform.childCount;
        //transform.GetChild(0).position = new Vector3(-.5f, -.5f, 0f);
        for (int i = childs - 1; i >= 0; i--)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                SpawnTile(x, y, ref texture);
            }
        }
    }

    [ContextMenu("Load Level For Editor")]
    void LoadAllTexturesOntoGrid()
    {
        LoadTextureOntoGrid(ref levelTilemap, ref levelTexture, ref levelMapDictionary.artKeys);
        LoadTextureOntoGrid(ref foregroundArtTilemap, ref foregroundArtTexture, ref artMapDictionary);
        LoadTextureOntoGrid(ref waterTilemap, ref waterTexture, ref artMapDictionary);
        LoadTextureOntoGrid(ref backgroundArtTilemap, ref backgroundArtTexture, ref artMapDictionary);
    }

    void LoadTextureOntoGrid(ref Tilemap tilemap, ref Texture2D texture, ref artKey[] keys)
    {
        tilemap.ClearAllTiles();

        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                SetTile(x, y, ref tilemap, ref texture, ref keys);
            }
        }
    }

    void SetTile(int x, int y, ref Tilemap tilemap, ref Texture2D texture, ref artKey[] keys)
    {
        Color color = texture.GetPixel(x, y);
        foreach (artKey key in keys)
        {
            if (color.Equals(key.color))
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), key.tile);
                return;
            }
        }
    }

    void SpawnTile(int x, int y, ref Texture2D texture)
    {
        Color color = texture.GetPixel(x, y);
        for (int i = 0; i < levelMapDictionary.artKeys.Length; i++)
        {
            artKey key = levelMapDictionary.artKeys[i];
            if (color.Equals(key.color))
            {
                if (levelMapDictionary.prefab[i] != null)
                {
                    Instantiate(levelMapDictionary.prefab[i], new Vector2(x + .5f, y + .5f), Quaternion.identity, transform);
                }
                else
                {
                    levelTilemap.SetTile(new Vector3Int(x, y, 0), key.tile);
                }
            }
        }
    }

    [ContextMenu("Save Level For Editor")]
    void SaveAllGridsToTextures()
    {
        SaveGridToTexture(ref levelTilemap, ref levelTexture, ref levelMapDictionary.artKeys);
        SaveGridToTexture(ref foregroundArtTilemap, ref foregroundArtTexture, ref artMapDictionary);
        SaveGridToTexture(ref waterTilemap, ref waterTexture, ref artMapDictionary);
        SaveGridToTexture(ref backgroundArtTilemap, ref backgroundArtTexture, ref artMapDictionary);
        SaveTexture(levelTexture);
        SaveTexture(foregroundArtTexture);
        SaveTexture(waterTexture);
        SaveTexture(backgroundArtTexture);
    }

    void SaveGridToTexture(ref Tilemap tilemap, ref Texture2D texture, ref artKey[] keys)
    {

        for (int x = 0; x < texture.width; x++)
        {
            for (int y = 0; y < texture.height; y++)
            {
                SetPixel(x, y, ref tilemap, ref texture, ref keys);
            }
        }
        texture.Apply();
    }

    void SetPixel(int x, int y, ref Tilemap tilemap, ref Texture2D texture, ref artKey[] keys)
    {
        texture.SetPixel(x, y, Color.white);

        TileBase tile = tilemap.GetTile(new Vector3Int(x, y, 0));
        foreach (artKey key in keys)
        {
            if (tile == key.tile)
            {
                texture.SetPixel(x, y, key.color);
            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(new Vector2(foregroundArtTexture.width/2, foregroundArtTexture.height/2) + new Vector2(0.0f, 0.5f), new Vector2(foregroundArtTexture.width, foregroundArtTexture.height));
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(new Vector2(waterTexture.width / 2, waterTexture.height / 2) + new Vector2(0.0f, 0.5f), new Vector2(waterTexture.width, waterTexture.height));
        Gizmos.color = Color.gray;
        Gizmos.DrawWireCube(new Vector2(backgroundArtTexture.width / 2, backgroundArtTexture.height / 2) + new Vector2(0.0f, 0.5f), new Vector2(backgroundArtTexture.width, backgroundArtTexture.height));
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(new Vector2(levelTexture.width / 2, levelTexture.height / 2) + new Vector2(0.0f, 0.5f), new Vector2(levelTexture.width, levelTexture.height));
    }
    
    protected void SaveTexture(Texture2D texture)
    {
        string path = Application.dataPath + "/Textures/Level Textures/" + texture.name + ".png";
        System.IO.File.WriteAllBytes(path, texture.EncodeToPNG());
        Debug.Log(path);
    }

    //protected Texture2D RetriveTexture(Texture2D texture)
    //{
    //    string path = Application.dataPath + "/Textures/Level Textures/" + texture.name + ".png";
    //    Texture2D newTexture = new Texture2D(texture.width, texture.height);
    //    newTexture.LoadImage(System.IO.File.ReadAllBytes(path));
    //    newTexture.name = texture.name;
    //
    //    Debug.Log(path);
    //
    //    return newTexture;
    //}


    [Header("Create Blank File Settings (Make sure name is not being used!)")]
    [SerializeField] string newName;
    [SerializeField] Vector2Int newSize;

    [ContextMenu("New Blank Texture (Make sure name is not being used!)")]
    void NewImageSet()
    {
        if(newName == "")
        {
            Debug.LogError("Requires a level name to create new texture.");
            return;
        }

        Texture2D newTexture = new Texture2D(newSize.x,newSize.y);
        newTexture.name = "Level" + newName;
        levelTexture = newTexture;

        Texture2D newATexture = new Texture2D(newSize.x, newSize.y);
        newATexture.name = "ForegroundArt" + newName;
        foregroundArtTexture = newATexture;

        Texture2D newBTexture = new Texture2D(newSize.x, newSize.y);
        newBTexture.name = "Water" + newName;
        waterTexture = newBTexture;

        Texture2D newCTexture = new Texture2D(newSize.x, newSize.y);
        newCTexture.name = "BackgroundArt" + newName;
        backgroundArtTexture = newCTexture;

        Debug.Log("New texture added. Must use \"Save Level For Editor\" to write file to the database.");
    }
}
