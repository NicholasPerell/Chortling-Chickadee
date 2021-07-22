using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastLittleAudioBits : MonoBehaviour
{
    FMOD.Studio.EventInstance snapshot;
    // Start is called before the first frame update
   public void CallButtonClickNoise()
    {
    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/UI/OptionsButtons/Select");
    }
    public void CallButtonCloseNoise()
    {  
    FMODUnity.RuntimeManager.PlayOneShot("event:/SFX Events/UI/OptionsButtons/CloseExit");
    }
    public void CallTextSnapshot()
    {
    snapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Text");
            snapshot.start();
    }
    public void CallEndTextSnapshot()
    {
         snapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            snapshot.release();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
