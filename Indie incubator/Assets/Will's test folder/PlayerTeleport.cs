using System.Collections;
using Unity.AI.Navigation;
using UnityEngine;
using UnityEngine.AI;

public class PlayerTeleport : MonoBehaviour
{
    [Header("Teleport Settings")]
    public Vector3 teleportOffset = new Vector3(0, 25, 0);
    public bool isTeleportingOnTimer = false;
    public float duration = 5f;
    //public float navMeshSampleRadius = 5f;
    //public float overlapCheckRadius = 0.5f;

    //[Header("Nav Mesh Surfaces")]
    //public NavMeshSurface navMeshA; // lower level
    //public NavMeshSurface navMeshB; // upper level

    [Header("VFX")]
    public GameObject vfx; // placeholder atm

    [Header("Dialogues")]
    public DialogueScriptableObject unableToTeleport;
    public DialogueScriptableObject firstTeleportIntoColliderWarning;
    public DialogueScriptableObject teleportTutorial;
    public DialogueScriptableObject teleportTutorialWarning;

    DialogueManager dialogueManager;
    Rigidbody rb;
    bool isTeleporting = false;
    bool firstWarningShown = false;
    bool tutorialShown = false;
    Coroutine teleportCoroutine;

    private void Start()
    {
        dialogueManager = FindFirstObjectByType<DialogueManager>();
        rb = GetComponent<Rigidbody>();
        isTeleporting = false;
        firstWarningShown = false;
        tutorialShown = false;
    }

    void Update()
    {
        if (isTeleportingOnTimer) // Player will teleport back after timer ends
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (!isTeleporting)
                {
                    teleportCoroutine = StartCoroutine(TeleportRoutine());
                }
                else
                {
                    StopCoroutine(teleportCoroutine);
                    Teleport();
                }
                
            }
        }
        else // Player has to manually teleport back
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                Teleport();
            }
        }

        // Show VFX when teleporting
        if (isTeleporting)
        {
            vfx.SetActive(true);
        }
        else vfx.SetActive(false);

        // Print player position
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            Debug.Log("Player current pos: " + rb.position);
        }
    }

    IEnumerator TeleportRoutine()
    {
        #region Teleport To
        // Check if hitting collider, prevent teleport if true
        if (isTeleportingIntoCollider(teleportOffset))
        {
            Debug.Log("Unable to teleport");
            if (unableToTeleport != null)
                dialogueManager.StartDialogue(unableToTeleport.dialogueLines);
            yield break;
        }

        // Teleport Player to level B
        Vector3 originalPos = rb.position;
        Vector3 targetPos = rb.position + teleportOffset;
        MovePlayer(targetPos);
        isTeleporting = !isTeleporting;
        #endregion

        yield return new WaitForSeconds(duration);

        #region Teleport Back
        // Check if hitting collider, teleport to original position if true
        if (isTeleportingIntoCollider(-teleportOffset))
        {
            MovePlayer(originalPos);
            isTeleporting = !isTeleporting;
            if (!firstWarningShown && !tutorialShown && teleportTutorialWarning != null)
            {
                dialogueManager.StartDialogue(teleportTutorialWarning.dialogueLines);
                firstWarningShown = true;
                tutorialShown = true;
            }
            if (!firstWarningShown && firstTeleportIntoColliderWarning != null)
            {
                dialogueManager.StartDialogue(firstTeleportIntoColliderWarning.dialogueLines);
                firstWarningShown = true;
            }          
        }
        else
        {
            Vector3 returnPos = rb.position - teleportOffset;
            MovePlayer(returnPos);
            isTeleporting = !isTeleporting;
        }

        if(!tutorialShown && teleportTutorial != null)
        {
            dialogueManager.StartDialogue(teleportTutorial.dialogueLines);
            tutorialShown = true;
        }
        #endregion
    }

    void Teleport()
    {
        // Check if hitting collider, prevent teleport if true
        if (isTeleportingIntoCollider(teleportOffset))
        {
            Debug.Log("Unable to teleport");
            if (unableToTeleport != null)
                dialogueManager.StartDialogue(unableToTeleport.dialogueLines);
            return;
        }
        // If on Level A, teleport to level B and vice versa
        if (!isTeleporting)
        {
            Vector3 targetPos = rb.position + teleportOffset;
            MovePlayer(targetPos);
            isTeleporting = !isTeleporting;
        }
        else
        {
            Vector3 targetPos = rb.position - teleportOffset;
            MovePlayer(targetPos);
            isTeleporting = !isTeleporting;
        }
    }

    void MovePlayer(Vector3 destination)
    {
        rb.MovePosition(destination);
        rb.linearVelocity = Vector3.zero;
    }

    bool isTeleportingIntoCollider(Vector3 offset)
    {
        Vector3 targetPos = transform.position + offset;
        Collider[] overlaps = Physics.OverlapSphere(targetPos, 0.5f); // check if target is in any collider
        if (overlaps.Length > 0)
        {
            //Debug.Log("Destination blocked");
            return true;
        }
        return false;
    }

}


    
    //IEnumerator Teleporting()
    //{
    //    isTeleporting = true;
    //    vfx.SetActive(true);

    //    // Pick which navmesh to land on based on current level
    //    NavMeshSurface targetSurface = isOnLevelA ? navMeshB : navMeshA;
    //    Vector3 targetOffset = isOnLevelA ? teleportOffset : -teleportOffset;

    //    Vector3 targetDestination = TryGetSafePosition(targetOffset, targetSurface);
    //    transform.position = targetDestination;
    //    rb.linearVelocity = Vector3.zero;
    //    Debug.Log("Teleported to: " + targetDestination);

    //    isOnLevelA = !isOnLevelA;

    //    yield return new WaitForSeconds(duration);

    //    // Return to original level
    //    NavMeshSurface returnSurface = isOnLevelA ? navMeshB : navMeshA;
    //    Vector3 returnOffset = isOnLevelA ? teleportOffset : -teleportOffset;

    //    Vector3 returnDestination = TryGetSafePosition(returnOffset, returnSurface);
    //    transform.position = returnDestination;
    //    rb.linearVelocity = Vector3.zero;
    //    Debug.Log("Returned to: " + returnDestination);

    //    isOnLevelA = !isOnLevelA;

    //    isTeleporting = false;
    //    vfx.SetActive(false);
    //}

    //Vector3 TryGetSafePosition(Vector3 offset, NavMeshSurface surface)
    //{
    //    Vector3 targetPos = transform.position + offset;

    //    Collider[] overlaps = Physics.OverlapSphere(targetPos, 0.5f); // check if target is in any collider

    //    if (overlaps.Length > 0)
    //    {
    //        Debug.Log("Destination blocked, finding safe navmesh position");
    //        NavMeshHit hit;
    //        if (NavMesh.SamplePosition(targetPos, out hit, navMeshSampleRadius, surface.layerMask))
    //        {
    //            return hit.position; // Get the nearest walkable area on the navmesh within the sample radius
    //        }
    //        Debug.LogWarning("No safe navmesh position found on " + surface.name);
    //    }
    //    return targetPos; 
    //}



    //IEnumerator TeleportRoutine()
    /*
����//{
����//����// Determine direction based on current level
����//����Vector3 goOffset��� = isOnLevelA ?� teleportOffset : -teleportOffset;
����//����Vector3 returnOffset = isOnLevelA ? -teleportOffset :� teleportOffset;

����//����NavMeshSurface targetSurface = isOnLevelA ? navMeshB : navMeshA;
����//����NavMeshSurface originSurface = isOnLevelA ? navMeshA : navMeshB;

����//����// --- Go ---
����//����Vector3 goDestination;
����//����if (!TryGetSafePosition(goOffset, targetSurface, out goDestination))
����//����{
����//��������Debug.Log("Unable to teleport: destination blocked and no safe navmesh fallback.");
����//��������yield break;
����//����}

����//����isTeleporting = true;
����//����vfx.SetActive(true);

����//����MovePlayer(goDestination);
����//����isOnLevelA = !isOnLevelA;
����//����Debug.Log("Teleported to: " + rb.position);

����//����yield return new WaitForSeconds(duration);

����//����// --- Return ---
����//����Vector3 returnDestination;
����//����if (!TryGetSafePosition(returnOffset, originSurface, out returnDestination))
����//����{
����//��������Debug.Log("Unable to return: destination blocked and no safe navmesh fallback. Player stays.");
����//��������// Optionally: keep player on upper level, flip flag to match
����//��������isTeleporting = false;
����//��������vfx.SetActive(false);
����//��������yield break;
����//����}

����//����MovePlayer(returnDestination);
����//����isOnLevelA = !isOnLevelA;
����//����Debug.Log("Returned to: " + rb.position);

����//����isTeleporting = false;
����//����vfx.SetActive(false);
����//}



����// Returns true if a safe position was found, outputs the destination
����//bool TryGetSafePosition(Vector3 offset, NavMeshSurface surface, out Vector3 destination)
����//{
����//����destination = rb.position + offset;

����//����Collider[] overlaps = Physics.OverlapSphere(destination, overlapCheckRadius);
����//����if (overlaps.Length == 0)
����//��������return true; // Clear path, use it directly

����//����Debug.Log("Destination blocked, sampling navmesh for fallback position.");

����//����NavMeshHit hit;
����//����int areaMask = 1 << NavMesh.GetAreaFromName("Walkable"); // Correct: area mask not layer mask
����//����if (NavMesh.SamplePosition(destination, out hit, navMeshSampleRadius, areaMask))
����//����{
����//��������destination = hit.position;
����//��������return true;
����//����}

����//����Debug.LogWarning("No safe navmesh position found near " + destination);
����//����return false;
����//}
}
*/