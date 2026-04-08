using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractable : MonoBehaviour
{
    // Remember to add Rigidbody to whatever this is attached to

    public string interactableTag;

    //public GameObject door;

    private GameObject objInRange;

    private void Update()
    {
        if (objInRange != null && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacted with object: " + objInRange.name);
            objInRange.GetComponent<Door>().PlayerInteract();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(interactableTag))
        {
            Debug.Log(other.name + " in range!");
            objInRange = other.gameObject;
        }          
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(interactableTag))
        {
            Debug.Log(other.name + " out of range!");
            objInRange = null;
        }
    }
}

