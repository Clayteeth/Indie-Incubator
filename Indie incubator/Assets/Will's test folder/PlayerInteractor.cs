using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    // Using Raycast to find interactable game object

    public float interactRange = 3f;
    public Camera playerCamera;

    public GameObject dialoguePanel;

    void Start()
    {
        if (playerCamera == null)
            playerCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        Ray ray = new Ray(playerCamera.transform.position, playerCamera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                //Debug.Log(hit.collider.name + " in range!");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // Prevent interaction when dialogue is active since there are problems
                    // when both interaction key and dialogue keys are the same
                    if (dialoguePanel != null && dialoguePanel.activeSelf)
                        return; 
                    else
                        interactable.Interact();
                    //Debug.Log("Interacted with: " + hit.collider.name);
                }
            }
        }
    } // Currently only for the door, but more interactable object can inherit from IInteractable
}
