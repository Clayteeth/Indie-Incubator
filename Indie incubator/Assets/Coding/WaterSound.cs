using UnityEngine;

public class WaterSound : MonoBehaviour
{
    public AudioSource soundEffect;

    // Turn this on from another object
    public bool disableSound = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !disableSound)
        {
            soundEffect.Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            soundEffect.Stop();
        }
    }
}