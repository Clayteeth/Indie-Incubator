using UnityEngine;

public class FlashlightSystem : MonoBehaviour
{
    public Transform button;          
    public float interactDistance = 3f;

    private Light lightComp;
    private bool unlocked = false;

    public AudioSource audioSource;

    public AudioSource audioSource1;

    void Start()
    {
        lightComp = GetComponent<Light>();
        lightComp.enabled = false; 
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, button.position) <= interactDistance && Input.GetKeyDown(KeyCode.E) && unlocked == false)
        {
            unlocked = true;
            audioSource1.Play();
            //Destroy(button.gameObject);
            button.GetComponentInChildren<MeshRenderer>().enabled = false;
        }


        if (unlocked == true && Input.GetKeyDown(KeyCode.F))
        {
            audioSource.Play();
            lightComp.enabled = !lightComp.enabled;
        }
    }
}