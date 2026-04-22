using UnityEngine;

public class EnemyContact : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().Die();
            Debug.Log("Player has been killed by a monster.");
        }
    }
}
