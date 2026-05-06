using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueEventTrigger : MonoBehaviour
{
    public DialogueScriptableObject dialogueScript; // Dialogue Scriptable Object
    public bool autoTrigger = false;
    public bool triggerOnlyOnce = true;
    internal bool hasTriggered;

    private bool playerInRange = false;

    private DialogueManager dialogueManager;

    public bool isLocked = false;

    void Start()
    {
        dialogueManager = FindFirstObjectByType<DialogueManager>();
        hasTriggered = false;
    }

    void Update()
    {
        if (triggerOnlyOnce)
            if (hasTriggered)
                gameObject.SetActive(false);

        if (playerInRange && autoTrigger)
        {
            if (isLocked)
                return;
            dialogueManager.StartDialogue(dialogueScript.dialogueLines);
            playerInRange = false;
            hasTriggered = true;
            gameObject.SetActive(false);
        }

        // Press E to activate Dialogue Event
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            if (isLocked)
                return;
            dialogueManager.StartDialogue(dialogueScript.dialogueLines);
            playerInRange = false;
            hasTriggered = true;
        }
    }

    public int GetDialogueTotalLines()
    {
        return dialogueScript.dialogueLines.Length;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player entered range of: " + gameObject.name);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left range of: " + gameObject.name);
        }
    }
}
