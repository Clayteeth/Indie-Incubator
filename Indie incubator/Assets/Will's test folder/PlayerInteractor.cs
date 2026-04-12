using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    // Using Raycast to find interactable game object

    public string interactableTag;
    public float interactRange = 3f;
    public Camera playerCamera;

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
                Debug.Log(hit.collider.name + " in range!");

                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("Interacted with: " + hit.collider.name);
                    interactable.Interact();
                }
            }
        }
    } // Currently only for the door, but more interactable object can inherit from IInteractable
}
