using UnityEngine;

public class ButtumWaterLevel : MonoBehaviour
{
    public Transform platform;
    public float lowerAmount = 5f;
    public float speed = 2f;

    public Transform doorOpen;
    public float openAmount = 5f;
    public float openSpeed = 2f;

    private bool playerInRange;
    private bool isLowering;
    private bool isOpening;

    private Vector3 waterTargetPos;
    private Vector3 doorTargetPos;

    public GameObject enemyA;
    public GameObject enemyTriggerA;
    public GameObject enemyTriggerB;

    void Start()
    {
        waterTargetPos = new Vector3(platform.position.x, platform.position.y - lowerAmount, platform.position.z);
        doorTargetPos = new Vector3(doorOpen.position.x + openAmount, doorOpen.position.y, doorOpen.position.z);
        enemyTriggerB.SetActive(false);
    }

    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            isLowering = true;
            isOpening = true;
            enemyA.SetActive(false);
            enemyTriggerA.SetActive(false);
            enemyTriggerB.SetActive(true);
        }

        if (isLowering == true)
        {
            platform.position = Vector3.MoveTowards(platform.position, waterTargetPos, speed * Time.deltaTime);

            if (Vector3.Distance(platform.position, waterTargetPos) < 0.01f)
            {
                isLowering = false;
            }
        }

        if (isOpening == true)
        {
            doorOpen.position = Vector3.MoveTowards(doorOpen.position, doorTargetPos, openSpeed * Time.deltaTime);

            if (Vector3.Distance(doorOpen.position, doorTargetPos) < 0.01f)
            {
                isOpening = false;
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