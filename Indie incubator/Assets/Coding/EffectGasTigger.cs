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

    public GameObject lightObject;

    public GameObject lightObject1;

    public GameObject lightObject2;

    public GameObject lightObject3;

    public GameObject lightObject4;

    public GameObject lightObject5;

    public GameObject lightObject6;

    public GameObject NlightObject7;

    public GameObject NlightObject8;

    public GameObject NlightObject9;

    public GameObject NlightObject10;

    public GameObject NlightObject11;

    public AudioSource audioSource;

    public AudioSource audioSource1;

    public AudioSource audioSource2;

    public AudioSource audioSource3;

    public AudioSource audioSource4;

    public float delay = 3f;

    public float delay1 = 1f;

    private bool hasTriggered = false;

    public Door door;

    void Start()
    {
        particleEffect.SetActive(false);
        particleEffect1.SetActive(false);
        particleEffect2.SetActive(false);
        particleEffect3.SetActive(false);
        particleEffect4.SetActive(false);
        lightObject.SetActive(false);
        lightObject1.SetActive(false);
        lightObject2.SetActive(false);  
        lightObject3.SetActive(false);
        lightObject4.SetActive(false);
        lightObject5.SetActive(false);
        lightObject6.SetActive(false);
        //particleEffect5.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasTriggered)
        {
            Debug.Log("Player entered the trigger area.");
            hasTriggered = true;

            audioSource1 .Play();

            Invoke(nameof(LightSwitch), delay1);
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

    void LightSwitch()
    {
        lightObject.SetActive(true);
        lightObject1.SetActive(true);
        lightObject2.SetActive(true);
        lightObject3.SetActive(true);
        lightObject4.SetActive(true);
        lightObject5.SetActive(true);
        lightObject6.SetActive(true);
        NlightObject7.SetActive(false);
        NlightObject8.SetActive(false);
        NlightObject9.SetActive(false);
        NlightObject10.SetActive(false);
        NlightObject11.SetActive(false);
    }
}