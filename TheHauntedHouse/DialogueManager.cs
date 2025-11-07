using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public NPCDialogue npc;

    bool isTalking = false;
    bool playerIsNear = false;
    int curResponseTracker = 0;

    public GameObject player;
    public GameObject dialogueUI;
    public GameObject DialogueTrigger;

    public TextMeshProUGUI npcName;
    public TextMeshProUGUI npcDialogueBox;
    public TextMeshProUGUI playerResponse;

    void Start()
    {
        dialogueUI.SetActive(false);
    }

    void Update()
    {
        if (playerIsNear && Input.GetKeyDown(KeyCode.F))
        {
            if (!isTalking)
            {
                StartConversation();
            }
            else
            {
                curResponseTracker++;
                if (curResponseTracker < npc.dialogue.Length)
                {
                    npcDialogueBox.text = npc.dialogue[curResponseTracker];
                    playerResponse.text = npc.playerDialogue[curResponseTracker];
                }
                else
                {
                    EndDialogue();
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerIsNear = true;
            DialogueTrigger.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerIsNear = false;
            DialogueTrigger.SetActive(false);
        }
    }

    void StartConversation()
    {
        isTalking = true;
        curResponseTracker = 0;
        dialogueUI.SetActive(true);
        npcName.text = npc.name;
        npcDialogueBox.text = npc.dialogue[0];
        playerResponse.text = npc.playerDialogue[0];
    }

    void EndDialogue()
    {
        isTalking = false;
        dialogueUI.SetActive(false);
    }
}
