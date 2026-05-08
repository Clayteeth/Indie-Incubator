using UnityEngine;
using System.Collections;

public class FadeInUI : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 2f;

    private void OnEnable()
    {
        StartCoroutine(FadeIn());
    }

    IEnumerator FadeIn()
    {
        canvasGroup.alpha = 0f;

        float time = 0f;

        while (time < fadeDuration)
        {
            time += Time.deltaTime;
            canvasGroup.alpha = time / fadeDuration;

            yield return null;
        }

        canvasGroup.alpha = 1f;
    }
}