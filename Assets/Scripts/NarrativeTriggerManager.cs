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

    DialogueRunner dialogueRunner;

    bool enterLH = true, exitLH = true, atlasH = true;

    void Start()
    {
        LevelCatalog levelCatalog = GameObject.FindObjectOfType<LevelCatalog>();
        levelCatalog.ChangeLevel += HandleChangeLevel;

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
        switch(name)
        {
            case "Inside Light House":
                if (enterLH)
                {
                    StartNarrative(enterLightHouse.nodeName);
                    enterLH = false;
                }
                break;
            case "Abandoned Town Lighthouseplace":
                if (exitLH)
                {
                    StartNarrative(exitLightHouse.nodeName);
                    exitLH = false;
                }
                break;
            case "Atlas House":
                if (atlasH)
                {
                    StartNarrative(atlasHouse.nodeName);
                    atlasH = false;
                }
                break;
        }
    }

    void StartNarrative(string startingNode)
    {

        dialogueRunner.startNode = startingNode;
        dialogueRunner.StartDialogue();

        GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetFloat("Speed", 0);
    }
}
