using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Cursor.lockState = CursorLockMode.Locked;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadSampleScene()
    {
        SceneManager.LoadScene("Act 1");
    }
}