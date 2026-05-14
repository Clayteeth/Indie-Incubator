using UnityEngine;
using System.Collections;
/*
public class EnemyKillPlayer : MonoBehaviour
{
    public GameObject deathUI;       
    public Transform respawnPoint;
    public Camera ClawCameraV;
    public Camera GroundCameraV;
    public float deathCutsceneTime;
    public Animator ENEMY_COPY;
    public PlayerMove playerScriptV;
    public Camera playerCameraV;
    public string Death_Start;

    private bool dead = false;

    private void OnTriggerEnter(Collider other)
    {
        if (dead) return;

        if (other.CompareTag("Player"))
        {
            dead = true;
            playerScriptV.enabled = false;
            playerCameraV.enabled = false;
            ENEMY_COPY.SetTrigger(Death_Start);
            StartCoroutine(DeathRoutine(other));
        
        }
    }

    IEnumerator DeathRoutine(Collider player)
    {
        

        //CharacterController cc = player.GetComponent<CharacterController>();
        //if (cc != null) cc.enabled = false;
        

        GroundCameraV.enabled = true;
        yield return new WaitForSeconds(17f);
        GroundCameraV.enabled = false;
        ClawCameraV.enabled = true;

        yield return new WaitForSeconds(53f);
        ClawCameraV.enabled = false;

        deathUI.SetActive(true);

        yield return new WaitForSeconds(2f);

        player.transform.position = respawnPoint.position;

        //if (cc != null) cc.enabled = true;
        playerScriptV.enabled = true;
        playerCameraV.enabled = true;

        deathUI.SetActive(false);

        dead = false;
    }
}
*/