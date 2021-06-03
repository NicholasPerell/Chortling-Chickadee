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
    public Texture2D levelTexture;
    public Texture2D artTexture;
    public Color[] groundColorKey = { Color.green, Color.black };
    public levelKey levelMapDictionary;
    public artKey[] artMapDictionary;

    public Tilemap levelTilemap;
    public Tilemap artTilemap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [ContextMenu("Load Level For Editor")]
    void LoadAllTexturesOntoGrid()
    {
        LoadTextureOntoGrid(ref levelTilemap, ref levelTexture, ref levelMapDictionary.artKeys);
        LoadTextureOntoGrid(ref artTilemap, ref artTexture, ref artMapDictionary);
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

    //void SpawnTile(int x, int y)
    //{
    //    Color color = levelTexture.GetPixel(x, y);
    //    foreach (Color key in groundColorKey)
    //        if (color.Equals(key))
    //        {
    //            groundTileMap.SetTile(new Vector3Int(x, y, 0), groundTile);
    //            return;
    //        }
    //
    //    foreach (levelKey key in levelMapDictionary)
    //    {
    //        if (color.Equals(key.color))
    //        {
    //            Instantiate(key.prefab, new Vector2(x, y), Quaternion.identity, transform);
    //        }
    //    }
    //}

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

}
