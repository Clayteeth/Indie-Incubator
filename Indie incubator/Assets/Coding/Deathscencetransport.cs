using UnityEngine;
using UnityEngine.SceneManagement;

public class Deathscencetransport : MonoBehaviour
{
    //public CanvasGroup uiPanel; // Assign your UI panel here
    public GameObject DeathUI; // Assign your player GameObject here

    public bool isPlayerDead = false;

    public GameObject player; // Assign your player GameObject here
    public Transform respawnPoint; // Assign the respawn point Transform here

    public CameraMovement cameraMovement;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DeathUI.SetActive(true);
            isPlayerDead = true;
            cameraMovement.enabled = false;
        }
    }

    public void Update()
    {
        if (isPlayerDead)
        {
            if (Input.GetKeyDown(KeyCode.V))
            {
                player.transform.position = respawnPoint.position;
                isPlayerDead = false;
                DeathUI.SetActive(false);
                cameraMovement.enabled = false;
            }
        }
    }



}
