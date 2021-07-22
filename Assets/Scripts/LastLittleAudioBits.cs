using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickSound : MonoBehaviour
{
    // Start is called before the first frame update
   public void CallButtonClickNoise()
{
    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/UI/OptionsButtons/Select");
}
public void CallButtonCloseNoise()
{
    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/UI/OptionsButtons/CloseExit");
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
