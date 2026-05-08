using UnityEngine;
using UnityEngine.SceneManagement;


public class WinCondition : MonoBehaviour
{
    public Transform player;
    public Transform goal;
    public float winDistance = 1f;
    private bool hasWon = false;
    void Update()
    {
        if (hasWon) return;
        float distance = Vector3.Distance(player.position, goal.position);
        //Debug.Log(distance);
        if (distance <= winDistance) 
        {
            hasWon = true;
            WinGame();
        }
    }
    void WinGame()
    {
        Debug.Log("You Win!");
        SceneManager.LoadScene("EndScene");
        
    }
}