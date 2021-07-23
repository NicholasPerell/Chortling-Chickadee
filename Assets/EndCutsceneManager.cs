using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class EndCutsceneManager : MonoBehaviour
{
    [SerializeField]
    string startingNode;
    [SerializeField]
    float triggerRadius;
    [SerializeField]
    GameObject invisibleBarrier;

    [HideInInspector]
    public PlayerMovementController player;

    bool cutsceneTriggered = false;

    DialogueRunner dialogueRunner;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMovementController>();
        dialogueRunner = GameObject.FindObjectOfType<DialogueRunner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (
            !cutsceneTriggered &&
            player.onGround &&
            player.rb.velocity.sqrMagnitude <= 0.1f &&
            player.appearanceModel.localScale.x == -1 &&
            Vector2.Distance(player.transform.position, transform.position) < triggerRadius
            )
        {
            cutsceneTriggered = true;
            Destroy(invisibleBarrier);
            dialogueRunner.startNode = startingNode;
            dialogueRunner.StartDialogue();

            player.enabled = false;
            player.GetComponent<PlayerStatsController>().enabled = false;
            player.GetComponent<SandAbilityManager>().enabled = false;

            GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>().SetFloat("Speed", 0);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, triggerRadius);
    }
}
