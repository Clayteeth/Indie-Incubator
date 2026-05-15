using UnityEngine;

public class SoundTigger : MonoBehaviour, IInteractable
{
    public AudioSource soundEffect;

    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    soundEffect.Play();
        //}
    }

    public void Interact()
    {
        soundEffect.Play();
    }
}
