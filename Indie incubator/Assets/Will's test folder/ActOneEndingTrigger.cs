using System.Collections;
using UnityEngine;

public class ActOneEndingTrigger : MonoBehaviour
{
    public Transform Act2SpawnPosition;
    public CanvasGroup fadePanel;
    public float freezeDuration = 2f;
    public float fadeDuration = 2f;

    private void Start()
    {
        fadePanel.alpha = 0f;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            StartCoroutine(TransitionRoutine(other));
        }
    }

    IEnumerator TransitionRoutine(Collider player)
    {
        #region Freeze Player
        Rigidbody rb = player.GetComponent<Rigidbody>();
        PlayerMove playerMove = player.GetComponent<PlayerMove>();
        CameraMovement cameraMovement = player.GetComponentInChildren<CameraMovement>();

        if (rb != null) rb.isKinematic = true;
        if (playerMove != null) playerMove.enabled = false;
        if (cameraMovement != null) cameraMovement.enabled = false;

        yield return new WaitForSeconds(freezeDuration);
        #endregion

        #region Fade To Black
        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadePanel.alpha = Mathf.Clamp01(timer / fadeDuration);
            yield return null;
        }
        fadePanel.alpha = 1f;
        #endregion

        // Teleport
        player.transform.position = Act2SpawnPosition.position;

        #region Fade Back In
        timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            fadePanel.alpha = Mathf.Clamp01(1f - (timer / fadeDuration));
            yield return null;
        }
        fadePanel.alpha = 0f;
        #endregion

        #region Unfreeze Player
        if (rb != null) rb.isKinematic = false;
        if (playerMove != null) playerMove.enabled = true;
        if (cameraMovement != null) cameraMovement.enabled = true;
        #endregion
    }
}
