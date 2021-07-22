using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceholderStartMusic : MonoBehaviour
{
    // Start is called before the first frame update
    private FMOD.Studio.EventInstance instance;

[FMODUnity.EventRef]
public string fmodEvent;
    void Start()
    {
        instance = FMODUnity.RuntimeManager.CreateInstance("event:/MUSIC");
        instance.start();
        instance.setParameterByName("Kalimba On", 1);
    }

    // Update is called once per frame
    //bool oop = true;
    //void Update()
    // {
    //     if (oop)
    //     {
    //         oop = false;
    //     }
    // }
}
