using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class EarningController : MonoBehaviour
{
    [SerializeField] SandAbilities ability;
    [SerializeField] float sandEarnt;
    FMOD.Studio.EventInstance snapshot;

    PlayerStatsController ply;

    private void Start()
    {
        name = "SandProjectileEarn";
        ply = GameObject.FindObjectOfType<PlayerStatsController>();
        if (ply.hasAbility[(int)ability])
        {
            Destroy(this.gameObject);
        }
    }

    [YarnCommand("Bestow")]
    public void BestowAbility()
    {
        ply.currentMaxSand = ply.currentMaxSand + sandEarnt;
        ply.hasAbility[(int)ability] = true;
        FMODUnity.RuntimeManager.PlayOneShot("event:/Stingers/Catalyst Unlock");

        StartCoroutine(nameof(StingerController));
        Destroy(GetComponent<InteractableController>());
    }

    IEnumerator StingerController(){
         snapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Stingers");
            snapshot.start();
            yield return new WaitForSecondsRealtime(5);
             snapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            snapshot.release();
            Destroy(this.gameObject);
    }
}
