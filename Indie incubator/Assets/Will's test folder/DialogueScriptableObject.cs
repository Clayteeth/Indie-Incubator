using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue/Dialogue Script")]
public class DialogueScriptableObject : ScriptableObject
{
    [System.Serializable]
    public class DialogueLine
    {
        public string dialogueText;
    }

    public DialogueLine[] dialogueLines; // Array of dialogue lines
}