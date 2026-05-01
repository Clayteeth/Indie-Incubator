using UnityEngine;

public class NonoGas : MonoBehaviour
{
    public Transform platform;
    public float lowerAmount = 5f;
    public float speed = 2f;

    private bool playerInRange;
    private bool isLowering;

    public GameObject particleEffect1;
    public GameObject particleEffect2;
    public GameObject particleEffect3;
    public GameObject particleEffect4;
    public GameObject particleEffect5;
    public GameObject particleEffect6;
    public GameObject particleEffect7;
    public GameObject particleEffect8;
    public GameObject particleEffect9;
    public GameObject particleEffect10;
    public GameObject particleEffect11;
    public GameObject particleEffect12;
    public GameObject particleEffect13;
    public GameObject particleEffect14;
    public GameObject particleEffect15;
    public GameObject gasTigger;

    public BoxCollider gasTiggerCollider;

    private Vector3 startPos;
    private Vector3 targetPos;

    void Start()
    {
        gasTiggerCollider = gasTigger.GetComponent<BoxCollider>();

        startPos = platform.position;
        targetPos = new Vector3(platform.position.x, platform.position.y - lowerAmount, platform.position.z);
    }

    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            isLowering = true;

            if (particleEffect1 != null)
            {
                particleEffect1.SetActive(false);
                particleEffect2.SetActive(false);
                particleEffect3.SetActive(false);
                particleEffect4.SetActive(false);
                particleEffect5.SetActive(false);
                particleEffect6.SetActive(false);
                particleEffect7.SetActive(false);
                particleEffect8.SetActive(false);
                particleEffect9.SetActive(false);
                particleEffect10.SetActive(false);
                particleEffect11.SetActive(false);
                particleEffect12.SetActive(false);
                particleEffect13.SetActive(false);
                particleEffect14.SetActive(false);
                particleEffect15.SetActive(false);
            }
            
            gasTiggerCollider.enabled = false;


            
        }

        if (isLowering == true)
        {
            platform.position = Vector3.MoveTowards(platform.position, targetPos, speed * Time.deltaTime);

            if (Vector3.Distance(platform.position, targetPos) < 0.01f)
            {
                isLowering = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }
}