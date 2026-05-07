using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float moveSpeed = 5f;
    public float jump = 7f;
    Vector3 movement; 
    Rigidbody rb;
    public float jumpCooldown = 1f;
    private float jumpTimer = 0f;
    float dashForce = 15f;
    public bool onElevator;
    public Transform currentElevator;

    public float lastElevatorY;


    public Vector3 MoveVec { get; private set;}

    public AudioSource footstepAudioSource;
    public AudioClip movementSound;
    private bool isMoving = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Get AudioSource if not assigned in inspector
        if (footstepAudioSource == null)
        {
            footstepAudioSource = GetComponent<AudioSource>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        jumpTimer -= Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.Space) && jumpTimer <= 0f)
        {
            Debug.Log("I try to jump");
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jump, rb.linearVelocity.z);
            jumpTimer = jumpCooldown;
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            Vector3 dashDirection = movement.normalized;

            rb.linearVelocity = new Vector3 (dashDirection.x * dashForce, rb.linearVelocity.y, dashDirection.z * dashForce);
        }
        
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement = (transform.right * x + transform.forward * z) * moveSpeed;
        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);

        // Check if player is moving
        bool playerMoving = (x != 0 || z != 0);

        // Play or stop sound based on movement state
        if (playerMoving && !isMoving)
        {
            // Start moving - play sound
            if (footstepAudioSource != null && movementSound != null)
            {
                footstepAudioSource.clip = movementSound;
                footstepAudioSource.loop = true;
                footstepAudioSource.Play();
            }
            isMoving = true;
        }
        else if (!playerMoving && isMoving)
        {
            // Stopped moving - stop sound
            if (footstepAudioSource != null)
            {
                footstepAudioSource.Stop();
            }
            isMoving = false;
        }

        if (onElevator == true && currentElevator != null)
        {
            float deltaY = currentElevator.position.y - lastElevatorY;

            transform.position = new Vector3(transform.position.x, transform.position.y + deltaY,transform.position.z);

            lastElevatorY = currentElevator.position.y;
        }



    }
}
