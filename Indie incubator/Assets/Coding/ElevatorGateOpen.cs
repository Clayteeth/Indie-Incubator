using UnityEngine;

public class ElevatorGateOpen : MonoBehaviour
{
    public Transform gate;
    public float openHeight = 5f;
    public float speed = 2f;
    [SerializeField] private float closeDelay = 10f;

    private bool playerInRange;
    private bool isOpening;
    private bool isOpen;
    private bool isClosing;

    private float timer = 0f;

    private Vector3 closedPos;
    private Vector3 openPos;

    void Start()
    {
        closedPos = gate.position;
        openPos = new Vector3(gate.position.x, gate.position.y + openHeight, gate.position.z);
    }

    void Update()
    {
        // PRESS E TO OPEN
        if (playerInRange == true && Input.GetKeyDown(KeyCode.E) && isOpening == false && isClosing == false)
        {
            isOpening = true;
        }

        // OPENING
        if (isOpening == true)
        {
            gate.position = Vector3.MoveTowards(gate.position, openPos, speed * Time.deltaTime);

            if (Vector3.Distance(gate.position, openPos) < 0.01f)
            {
                isOpening = false;
                isOpen = true;
                timer = closeDelay;
            }
        }

        // TIMER COUNTDOWN
        if (isOpen == true)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                isOpen = false;
                isClosing = true;
            }
        }

        // CLOSING
        if (isClosing == true)
        {
            gate.position = Vector3.MoveTowards(gate.position, closedPos, speed * Time.deltaTime);

            if (Vector3.Distance(gate.position, closedPos) < 0.01f)
            {
                isClosing = false;
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