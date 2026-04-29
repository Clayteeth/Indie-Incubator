using UnityEngine;
using System.Collections;

public class Monster_Intro_Trigger : MonoBehaviour
{
    public GameObject monsterIntroObject;
    public Animator monsterIntroAnimator;
    public string monsterIntroTrigger;
    public PlayerMove playerScriptV;
    public Camera playerCameraV;
    public Camera monsterCameraV;
    public float cutsceneTime;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerScriptV.enabled = false;
            playerCameraV.enabled = false;
            monsterIntroObject.SetActive(true);
            monsterIntroAnimator.SetTrigger(monsterIntroTrigger);
            StartCoroutine(cutsceneRoutine());
        }
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
    IEnumerator cutsceneRoutine()
    {
        yield return new WaitForSeconds(cutsceneTime);
        playerScriptV.enabled = true;
        playerCameraV.enabled = true;
        monsterCameraV.enabled = false;
    }
}
