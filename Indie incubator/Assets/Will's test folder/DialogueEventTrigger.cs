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
    //public GameObject objFlag;

    void Start()
    {
        //dialogueManager = FindObjectOfType<DialogueManager>();
        dialogueManager = FindFirstObjectByType<DialogueManager>();
        hasTriggered = false;
    }

    void Update()
    {
        if (triggerOnlyOnce)
            if (hasTriggered)
                gameObject.SetActive(false);

        //if (!objFlag.activeSelf || objFlag == null)
        //    isLocked = false;

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

        //if (playerInRange && Input.GetKeyDown(KeyCode.T)) //AYYY IM TESTING OVER HERE
        //{
        //    string totalLines = GetDialogueTotalLines().ToString();
        //    Debug.Log(totalLines);
        //}
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
            Debug.Log("Player entered range!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Debug.Log("Player left range!");
        }
    }
}
