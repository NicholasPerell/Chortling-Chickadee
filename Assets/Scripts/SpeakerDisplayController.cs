using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;
using TMPro;

[System.Serializable]
public struct SpeakerDictionary
{
    public string id;
    public string name;
    public Sprite img;
}

public class SpeakerDisplayController : MonoBehaviour
{
    public Image img;
    public TextMeshProUGUI nameDisplay;
    public SpeakerDictionary[] speakerDictionary;
    Dictionary<string, SpeakerDictionary> speakers;

    private void Start()
    {
        speakers = new Dictionary<string, SpeakerDictionary>();
        foreach (SpeakerDictionary e in speakerDictionary)
        {
            speakers.Add(e.id,e);
        }
    }


    [YarnCommand("changeSpeaker")]
    public void NextSlide(string speakerID)
    {
        if(speakers.ContainsKey(speakerID))
        {
            nameDisplay.text = speakers[speakerID].name;
            img.sprite = speakers[speakerID].img;
        }
        else
        {
            Debug.LogError("\"" + speakerID + "\" is not an existing speaker ID.");
        }
    }
}
