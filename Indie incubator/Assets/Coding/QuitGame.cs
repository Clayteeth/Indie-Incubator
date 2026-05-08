using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class Quit : MonoBehaviour
{
    public void QuitGame()
    {
        Debug.Log("Quit Game clicked");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}