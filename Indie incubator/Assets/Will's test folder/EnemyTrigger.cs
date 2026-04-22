using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameObject enemy;
    public bool isDisabledOnStart = true;

    private void Start()
    {
        if (isDisabledOnStart) 
            enemy.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            enemy.SetActive(true);
        }
    }
}
