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

    public AudioSource audioSource;

    public AudioSource audioSource1;

    public AudioSource audioSource2;

    public AudioSource audioSource3;

    public AudioSource audioSource4;

    public float delay = 3f;

    private bool hasTriggered = false;

    public Door door;

    void Start()
    {
        particleEffect.SetActive(false);
        particleEffect1.SetActive(false);
        particleEffect2.SetActive(false);
        particleEffect3.SetActive(false);
        particleEffect4.SetActive(false);
        //particleEffect5.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            Debug.Log("Player entered the trigger area.");
            hasTriggered = true;

            audioSource1 .Play();


            Invoke(nameof(PlayEffect), delay);
            Invoke(nameof(PlaySound), delay);

            if (other.CompareTag("Player"))
            {
                door.isLocked = false;

                Debug.Log("Door unlocked");

                //stroy(gameObject);
            }
        }
    }

    void PlayEffect()
    {
        if (particleEffect != null)
        {
            particleEffect.SetActive(true);
            particleEffect1.SetActive(true);
            particleEffect2.SetActive(true);
            particleEffect3.SetActive(true);
            particleEffect4.SetActive(true);
            //particleEffect5.SetActive(true);
        }
    }
    void PlaySound()
    {
        //dioSource.SetActive(true);
        audioSource.Play();
        audioSource2.Play();
        audioSource3.Play();
        audioSource4.Play();
    }
}