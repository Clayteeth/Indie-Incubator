using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public GameObject dialogueUIPanel;
    public TMP_Text dialogueText;

    private DialogueScriptableObject.DialogueLine[] currentDialogue;
    private int currentLineIndex;
    private bool isDialogueActive = false;
    private bool canAdvance = false;

    private void Start()
    {
        dialogueUIPanel.SetActive(false);
    }

    void Update()
    {
        if (isDialogueActive && Input.GetKeyDown(KeyCode.E) && canAdvance)
        {
            NextDialogueLine();
        }
        //if (Input.GetKeyDown(KeyCode.E))
        //    Debug.Log("E pressed");
    }

    public void StartDialogue(DialogueScriptableObject.DialogueLine[] dialogueLines)
    {
        //if (currentDialogue != null && currentDialogue.Length > 0)
        //    Debug.Log("Starting dialogue at index: " + currentLineIndex);

        currentDialogue = dialogueLines;
        currentLineIndex = 0;
        isDialogueActive = true;
        dialogueUIPanel.SetActive(true);

        ShowLine();
        canAdvance = true;
    }

    void ShowLine()
    {
        //Debug.Log("Showing line: " + currentLineIndex);
        DialogueScriptableObject.DialogueLine line = currentDialogue[currentLineIndex];
        dialogueText.text = line.dialogueText;
    }

    void NextDialogueLine()
    {
        currentLineIndex++;

        if (currentLineIndex >= currentDialogue.Length)
        {
            EndDialogue();
        }
        else
        {
            ShowLine();
        }
    }

    void EndDialogue()
    {
        isDialogueActive = false;
        dialogueUIPanel.SetActive(false);
    }
}
