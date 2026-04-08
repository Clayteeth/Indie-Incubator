using UnityEngine;

public class DeathBox : MonoBehaviour
{
    public Transform respawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player")) //Respawning player when they fell off the map
        {
            Debug.Log("Player fell off");
            other.transform.position = respawnPoint.position;
        }
    }
}
