using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ChangeMusicLayerDirection
{
    KEEP_PREVIOUS,
    TURN_ON,
    TURN_OFF
}

[System.Serializable]
public struct LayerSettingsForLevel
{
    public ChangeMusicLayerDirection kalimba;
    public ChangeMusicLayerDirection harpMarimba;
    public ChangeMusicLayerDirection piano;
    public ChangeMusicLayerDirection celeste;
    public ChangeMusicLayerDirection shakerLatinPercussion;
    public ChangeMusicLayerDirection celli;
    public ChangeMusicLayerDirection flute;
    public ChangeMusicLayerDirection clarinetUkulele;
    public ChangeMusicLayerDirection bass;
    public ChangeMusicLayerDirection timpani;
    public ChangeMusicLayerDirection highStrings;
    public ChangeMusicLayerDirection orchestralPercussion;
}

[System.Serializable]
public struct LevelLayerDictionary
{
    public string name;
    public LayerSettingsForLevel layerSettings;
}

[System.Serializable]
public struct ParameterNamesForLayers
{
    public string kalimba;
    public string harpMarimba;
    public string piano;
    public string celeste;
    public string shakerLatinPercussion;
    public string celli;
    public string flute;
    public string clarinetUkulele;
    public string bass;
    public string timpani;
    public string highStrings;
    public string orchestralPercussion;
}

public struct LayerArray
{
    public ChangeMusicLayerDirection[] arr;
}

public class MainMusicLayerController : MonoBehaviour
{
    [SerializeField] ParameterNamesForLayers parameterNamesPerLayer;
    string[] parameters;

    [SerializeField] LevelLayerDictionary[] levelSettings;
    Dictionary<string, LayerArray> map;

    [SerializeField] LayerSettingsForLevel startingLayerSettings;
    LayerArray startArr;

    private void Awake()
    {
        parameters = new string[12];
        parameters[0] = parameterNamesPerLayer.kalimba;
        parameters[1] = parameterNamesPerLayer.harpMarimba;
        parameters[2] = parameterNamesPerLayer.piano;
        parameters[3] = parameterNamesPerLayer.celeste;
        parameters[4] = parameterNamesPerLayer.shakerLatinPercussion;
        parameters[5] = parameterNamesPerLayer.celli;
        parameters[6] = parameterNamesPerLayer.flute;
        parameters[7] = parameterNamesPerLayer.clarinetUkulele;
        parameters[8] = parameterNamesPerLayer.bass;
        parameters[9] = parameterNamesPerLayer.timpani;
        parameters[10] = parameterNamesPerLayer.highStrings;
        parameters[11] = parameterNamesPerLayer.orchestralPercussion;

        startArr.arr = new ChangeMusicLayerDirection[12];
        startArr.arr[0] = startingLayerSettings.kalimba;
        startArr.arr[1] = startingLayerSettings.harpMarimba;
        startArr.arr[2] = startingLayerSettings.piano;
        startArr.arr[3] = startingLayerSettings.celeste;
        startArr.arr[4] = startingLayerSettings.shakerLatinPercussion;
        startArr.arr[5] = startingLayerSettings.celli;
        startArr.arr[6] = startingLayerSettings.flute;
        startArr.arr[7] = startingLayerSettings.clarinetUkulele;
        startArr.arr[8] = startingLayerSettings.bass;
        startArr.arr[9] = startingLayerSettings.timpani;
        startArr.arr[10] = startingLayerSettings.highStrings;
        startArr.arr[11] = startingLayerSettings.orchestralPercussion;

        for (int i = 0; i < startArr.arr.Length; i++)
        {
            FMODMagic(parameters[i], startArr.arr[i]);
        }

        map = new Dictionary<string, LayerArray>();
        foreach(LevelLayerDictionary e in levelSettings)
        {
            LayerArray layerArray;
            layerArray.arr = new ChangeMusicLayerDirection[12];

            layerArray.arr[0] = e.layerSettings.kalimba;
            layerArray.arr[1] = e.layerSettings.harpMarimba;
            layerArray.arr[2] = e.layerSettings.piano;
            layerArray.arr[3] = e.layerSettings.celeste;
            layerArray.arr[4] = e.layerSettings.shakerLatinPercussion;
            layerArray.arr[5] = e.layerSettings.celli;
            layerArray.arr[6] = e.layerSettings.flute;
            layerArray.arr[7] = e.layerSettings.clarinetUkulele;
            layerArray.arr[8] = e.layerSettings.bass;
            layerArray.arr[9] = e.layerSettings.timpani;
            layerArray.arr[10] = e.layerSettings.highStrings;
            layerArray.arr[11] = e.layerSettings.orchestralPercussion;

            map.Add(e.name, layerArray);
        }

        FindObjectOfType<LevelCatalog>().ChangeLevel += HandleNewLevel;
        GameManager.ChangeGameMode += HandleDeathPossibly;
    }

    void HandleNewLevel(string name)
    {
        if(map.ContainsKey(name))
        {
            LayerArray layerArray = map[name];
            for(int i = 0; i < layerArray.arr.Length; i++)
            {
                FMODMagic(parameters[i], layerArray.arr[i]);
            }
        }
    }

    void HandleDeathPossibly(GameMode mode)
    {
        if(mode == GameMode.DEATH)
        {
            for (int i = 0; i < parameters.Length; i++)
            {
                FMODMagic(parameters[i], ChangeMusicLayerDirection.TURN_OFF);
            }
        }
    }

    void FMODMagic(string param, ChangeMusicLayerDirection change)
    {
        switch (change)
        {
            case ChangeMusicLayerDirection.KEEP_PREVIOUS:
                break;
            case ChangeMusicLayerDirection.TURN_ON:
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName(param, 1);
                break;
            case ChangeMusicLayerDirection.TURN_OFF:
                FMODUnity.RuntimeManager.StudioSystem.setParameterByName(param, 0);
                break;
        }
    }
}
