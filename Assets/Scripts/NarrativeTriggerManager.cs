using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

[System.Serializable]
public struct ScriptNodePair
{
    public YarnProgram yarn;
    public string nodeName;
}

public class NarrativeTriggerManager : MonoBehaviour
{
    [Header("Yarn Scripts")]
    [SerializeField] ScriptNodePair enterLightHouse;
    [SerializeField] ScriptNodePair exitLightHouse;
    [SerializeField] ScriptNodePair atlasHouse;
    [SerializeField] string encounterNode, defeatNode, acidNode, finaleNode;

    DialogueRunner dialogueRunner;

    bool enterLH = true, exitLH = true, atlasH = true, encounter = true, defeat = true, acid = true, finale = true;

    PlayerStatsController plyStats;
    void Start()
    {
        LevelCatalog levelCatalog = GameObject.FindObjectOfType<LevelCatalog>();
        levelCatalog.ChangeLevel += HandleChangeLevel;
        plyStats = GameObject.FindObjectOfType<PlayerStatsController>();
        plyStats.AggroCrab += HandleEncounter;
        CrabAnimationTriggers.CrabDeath += HandleCrabDeath;

        dialogueRunner = GameObject.FindObjectOfType<DialogueRunner>();
    }

    bool oop = false;
    private void Update()
    {
        if (oop)
        {
            dialogueRunner.Add(enterLightHouse.yarn);
            dialogueRunner.Add(exitLightHouse.yarn);
            dialogueRunner.Add(atlasHouse.yarn);
            oop = false;
        }
    }

    void HandleChangeLevel(string name)
    {
        bool changes = false;

        switch (name)
        {
            case "Inside Light House":
                if (enterLH)
                {
                    StartNarrative(enterLightHouse.nodeName);
                    enterLH = false;
                    changes = true;
                }
                break;
            case "Abandoned Town Lighthouseplace":
                if (exitLH)
                {
                    StartNarrative(exitLightHouse.nodeName);
                    exitLH = false;
                    changes = true;
                }
                break;
            case "Atlas House":
                if (atlasH)
                {
                    StartNarrative(atlasHouse.nodeName);
                    atlasH = false;
                    changes = true;
                }
                break;
        }

        if (!changes)
        {
            if (killedCrab && defeat)
            {
                StartNarrative(defeatNode);
                defeat = false;
            }
        }
    }

    void HandleEncounter()
    {
        StartNarrative(encounterNode);
        encounter = false;
        plyStats.AggroCrab -= HandleEncounter;
    }

    [SerializeField] bool killedCrab = false;
    void HandleCrabDeath()
    {
        killedCrab = true;
        CrabAnimationTriggers.CrabDeath -= HandleCrabDeath;
    }

    void StartNarrative(string startingNode)
    {

        dialogueRunner.startNode = startingNode;
        dialogueRunner.StartDialogue();

        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetFloat("Speed", 0);
    }


}
