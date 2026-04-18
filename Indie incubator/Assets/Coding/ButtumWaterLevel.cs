using UnityEngine;

public class ButtumWaterLevel : MonoBehaviour
{
    public Transform platform;
    public float lowerAmount = 5f;
    public float speed = 2f;

    private bool playerInRange;
    private bool isLowering;

    private Vector3 startPos;
    private Vector3 targetPos;

    void Start()
    {
        startPos = platform.position;
        targetPos = new Vector3(platform.position.x, platform.position.y - lowerAmount, platform.position.z);
    }

    void Update()
    {
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E))
        {
            isLowering = true;
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