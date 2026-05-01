using UnityEngine;
using System.Collections;

public class EnemyKillPlayer : MonoBehaviour
{
    public GameObject deathUI;       
    public Transform respawnPoint;   

    private bool dead = false;

    private void OnTriggerEnter(Collider other)
    {
        if (dead) return;

        if (other.CompareTag("Player"))
        {
            dead = true;
            StartCoroutine(DeathRoutine(other));
        }
    }

    IEnumerator DeathRoutine(Collider player)
    {
        deathUI.SetActive(true);

        CharacterController cc = player.GetComponent<CharacterController>();
        if (cc != null) cc.enabled = false;

        yield return new WaitForSeconds(2f);

        player.transform.position = respawnPoint.position;

        if (cc != null) cc.enabled = true;

        deathUI.SetActive(false);

        dead = false;
    }
}