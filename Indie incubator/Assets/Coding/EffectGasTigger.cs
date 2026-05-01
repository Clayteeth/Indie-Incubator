using UnityEngine;

public class EffectGasTigger : MonoBehaviour
{
    public GameObject particleEffect;
    public GameObject particleEffect1;
    public GameObject particleEffect2;
    public GameObject particleEffect3;
    public GameObject particleEffect4;
    public GameObject particleEffect5;
    public GameObject particleEffect6;
    public GameObject particleEffect7;
    public GameObject particleEffect8;

    public float delay = 3f;

    private bool hasTriggered = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;
            Invoke(nameof(PlayEffect), delay);
        }
    }

    void PlayEffect()
    {
        if (particleEffect != null)
        {
            //particleEffect.Play();
           
        }
    }
}