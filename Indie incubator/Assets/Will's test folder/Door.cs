using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public float doorSpeed = 2f; // 0.5 second
    public Vector3 rotationAngle;
    public bool isLocked = false;
    public DialogueScriptableObject doorLockedDialogue;

    public DialogueManager dialogueManager;

    private Quaternion closedRotation;
    private Quaternion openRotation;

    private Quaternion startRotation;
    private Quaternion targetRotation;

    bool isClosed = true;
    bool isRotating = false;
    float swingProgress = 0f; // go from 0 to 1

    void Start()
    {
        dialogueManager = FindFirstObjectByType<DialogueManager>();
        closedRotation = transform.rotation;
        openRotation = transform.rotation * Quaternion.Euler(rotationAngle);
        targetRotation = closedRotation;
    }

    void Update()
    {
        if (isRotating)
        {
            swingProgress += Time.deltaTime * doorSpeed;

            // Make the door swing fast at the start and slow down at the end
            float easedSwingProgress = 1f - Mathf.Pow(1f - Mathf.Clamp01(swingProgress), 3f);
            transform.rotation = Quaternion.Slerp(startRotation, targetRotation, easedSwingProgress);

            if (swingProgress >= 1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
                swingProgress = 0f;
            } // just snap to target rotation
        }
    }

    public void Interact()
    {
        if (isLocked)
        {
            if (doorLockedDialogue != null)
            {
                dialogueManager.StartDialogue(doorLockedDialogue.dialogueLines);
                //Debug.Log("Door is locked");
            }
            return;
        }

        if (isRotating) return;

        isClosed = !isClosed;
        isRotating = true;
        swingProgress = 0f;
        startRotation = transform.rotation;
        targetRotation = isClosed ? closedRotation : openRotation; // if isClosed is true, use closedRotation, else use openRotation
    }
}
