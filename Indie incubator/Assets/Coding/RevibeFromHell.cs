using UnityEngine;
using UnityEngine.SceneManagement;

public class RevibeFromHell : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public Transform Act2SpawnPosition;
    public CanvasGroup fadePanel;
    public float freezeDuration = 2f;
    public float fadeDuration = 2f;
    // Update is called once per frame
    void Update()
    {
        
    }
    private void Start()
    {
    }
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("Act 1");
        Cursor.visible = false;
    }

    public void TriggerTransition()
    {
        // Load Act 1 first
        SceneManager.LoadScene("Act 1");
        Cursor.visible = false;
        
        // Wait a frame then find player and respawn
        StartCoroutine(RespawnPlayerAfterSceneLoad());
    }

    private System.Collections.IEnumerator RespawnPlayerAfterSceneLoad()
    {
        yield return null; // Wait one frame for scene to load
        
        // Find and respawn player
        Collider playerCollider = FindObjectOfType<Collider>();
        if (playerCollider != null)
        {
            playerCollider.transform.position = Act2SpawnPosition.position;
        }
    }
}
