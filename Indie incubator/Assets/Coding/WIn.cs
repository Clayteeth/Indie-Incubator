using UnityEngine;
using UnityEngine.SceneManagement;


public class WinCondition : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("You Win!");
        SceneManager.LoadScene("EndScene");
        Cursor.visible = true;
    }
}