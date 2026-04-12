using System.Collections;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public Transform respawnPoint;
    public float deathDelay = 1f;
    public float respawnDelay = 3f;
    bool isDying = false;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && !isDying) //Respawning player when they fell off the map
        {
            StartCoroutine(DeathRoutine(other));
        }
    }

    IEnumerator DeathRoutine(Collider player)
    {
        isDying = true;

        Rigidbody rb = player.GetComponent<Rigidbody>();
        PlayerMove playerMove = player.GetComponent<PlayerMove>();
        CameraMovement cameraMovement = player.GetComponentInChildren<CameraMovement>();

        // Disable player input and freeze in place
        // It would be cool if they are ragged doll or something idk I will need to figure that out
        if (rb != null) rb.isKinematic = true;
        if (playerMove != null) playerMove.enabled = false;
        if (cameraMovement != null) cameraMovement.enabled = false;

        yield return new WaitForSeconds(deathDelay);
        Debug.Log("Player fell off"); // Place holder, add a fade-in UI saying player drown or something
        yield return new WaitForSeconds(respawnDelay);

        // Respawn and return player input
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.position = respawnPoint.position;
        }
        if (playerMove != null) playerMove.enabled = true;
        if (cameraMovement != null) cameraMovement.enabled = true;

        isDying = false;
    }
}
