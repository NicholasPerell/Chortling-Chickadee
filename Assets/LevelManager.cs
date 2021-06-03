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
    public Texture2D artTexture;
    public levelKey levelMapDictionary;
    public artKey[] artMapDictionary;

    [Header("Tilemaps")]
    public Tilemap levelTilemap;
    public Tilemap artTilemap;

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
        LoadLevel(levelTexture, artTexture);
    }

    void LoadLevel(Texture2D lvl, Texture2D art)
    {
        LoadTextureOntoGrid(ref artTilemap, ref art, ref artMapDictionary);
        GenerateLevelFromTexture(ref lvl);
    }

    void GenerateLevelFromTexture(ref Texture2D texture)
    {
        levelTilemap.ClearAllTiles();

        int childs = transform.childCount;
        //transform.GetChild(0).position = new Vector3(-.5f, -.5f, 0f);
        for (int i = childs - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }

        for (int x = 0; x < levelTexture.width; x++)
        {
            for (int y = 0; y < levelTexture.height; y++)
            {
                SpawnTile(x, y, ref texture);
            }
        }
    }

    [ContextMenu("Load Level For Editor")]
    void LoadAllTexturesOntoGrid()
    {
        LoadTextureOntoGrid(ref levelTilemap, ref levelTexture, ref levelMapDictionary.artKeys);
        LoadTextureOntoGrid(ref artTilemap, ref artTexture, ref artMapDictionary);
        SaveTexture(levelTexture);
        SaveTexture(artTexture);
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
        SaveGridToTexture(ref artTilemap, ref artTexture, ref artMapDictionary);
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
        Gizmos.DrawWireCube(new Vector2(artTexture.width/2, artTexture.height/2) + new Vector2(0.0f, 0.5f), new Vector2(artTexture.width, artTexture.height));
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(new Vector2(levelTexture.width / 2, levelTexture.height / 2) + new Vector2(0.0f, 0.5f), new Vector2(levelTexture.width, levelTexture.height));
    }
    
    protected void SaveTexture(Texture2D texture)
    {
        string path = Application.dataPath + "/Textures/Level Textures/" + texture.name + ".png";
        System.IO.File.WriteAllBytes(path, texture.EncodeToPNG());
        Debug.Log(path);
    }

}
