using System.Collections;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerTeleport : MonoBehaviour
{
    public Vector3 teleportOffset = new Vector3(0, 25, 0);

    public float duration = 5f;

    public float navMeshSampleRadius = 5f;
    public NavMeshSurface navMeshA; // lower level
    public NavMeshSurface navMeshB; // upper level

    private bool isTeleporting = false;
    private bool isOnLevelA = true;
    Rigidbody rb;

    public GameObject vfx; // placeholder atm

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        vfx.SetActive(false);
        isOnLevelA = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isTeleporting)
        {
            StartCoroutine(Teleporting2());
        }
        if (Input.GetKeyDown(KeyCode.P)) //Get player position
        {
            Debug.Log("Player current pos: " + rb.position);
        }
    }

    IEnumerator Teleporting2()
    {
        // check if hitting collider
        // TP to offset if no, unable to TP if yes
        if(isTeleportingIntoCollider(teleportOffset))
        {
            Debug.Log("Unable to teleport");
            yield break;
        }

        isTeleporting = true;
        vfx.SetActive(true);

        Vector3 originalPos = rb.position;
        Debug.Log("Original Pos Step 1: " +originalPos);
        Vector3 targetPos = rb.position + teleportOffset;
        rb.position = targetPos;

        yield return new WaitForSeconds(duration);

        // check if hitting collider
        // TP to offset if no, TP to original pos if yes
        Debug.Log("Original Pos Step 2: " + originalPos);
        if (isTeleportingIntoCollider(-teleportOffset))
        {
            Debug.Log("Teleporting to original pos: " +originalPos);
            rb.position = originalPos;
            Debug.Log("Player current pos: " + rb.position);
            //yield return new WaitForSecondsRealtime(0.5f);
            //Time.timeScale = 0f;
            //yield return new WaitForSecondsRealtime(0.5f);
            //Time.timeScale = 1f;
        }
        else
        {
            Vector3 returnPos = rb.position - teleportOffset;
            rb.position = returnPos;
        }
        

        isTeleporting = false;
        vfx.SetActive(false);
    }

    IEnumerator Teleporting()
    {
        isTeleporting = true;
        vfx.SetActive(true);

        // Pick which navmesh to land on based on current level
        NavMeshSurface targetSurface = isOnLevelA ? navMeshB : navMeshA;
        Vector3 targetOffset = isOnLevelA ? teleportOffset : -teleportOffset;

        Vector3 targetDestination = TryGetSafePosition(targetOffset, targetSurface);
        transform.position = targetDestination;
        rb.linearVelocity = Vector3.zero;
        Debug.Log("Teleported to: " + targetDestination);

        isOnLevelA = !isOnLevelA;

        yield return new WaitForSeconds(duration);

        // Return to original level
        NavMeshSurface returnSurface = isOnLevelA ? navMeshB : navMeshA;
        Vector3 returnOffset = isOnLevelA ? teleportOffset : -teleportOffset;

        Vector3 returnDestination = TryGetSafePosition(returnOffset, returnSurface);
        transform.position = returnDestination;
        rb.linearVelocity = Vector3.zero;
        Debug.Log("Returned to: " + returnDestination);

        isOnLevelA = !isOnLevelA;

        isTeleporting = false;
        vfx.SetActive(false);
    }

    Vector3 TryGetSafePosition(Vector3 offset, NavMeshSurface surface)
    {
        Vector3 targetPos = transform.position + offset;

        Collider[] overlaps = Physics.OverlapSphere(targetPos, 0.5f); // check if target is in any collider

        if (overlaps.Length > 0)
        {
            Debug.Log("Destination blocked, finding safe navmesh position");
            NavMeshHit hit;
            if (NavMesh.SamplePosition(targetPos, out hit, navMeshSampleRadius, surface.layerMask))
            {
                return hit.position; // Get the nearest walkable area on the navmesh within the sample radius
            }
            Debug.LogWarning("No safe navmesh position found on " + surface.name);
        }
        return targetPos; 
    }

    bool isTeleportingIntoCollider(Vector3 offset)
    {
        Vector3 targetPos = transform.position + offset;
        Collider[] overlaps = Physics.OverlapSphere(targetPos, 0.5f); // check if target is in any collider
        if (overlaps.Length > 0)
        {
            Debug.Log("Destination blocked");
            return true;          
        }
        return false;
    }
}
