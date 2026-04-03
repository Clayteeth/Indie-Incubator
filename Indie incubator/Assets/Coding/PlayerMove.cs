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


    public Vector3 MoveVec { get; private set;}

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        jumpTimer -= Time.deltaTime;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        movement = (transform.right * x + transform.forward * z) * moveSpeed;

        rb.linearVelocity = new Vector3(movement.x, rb.linearVelocity.y, movement.z);


        if (Input.GetKeyDown(KeyCode.Space) && jumpTimer <= 0f)
        {

            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jump, rb.linearVelocity.z);
            jumpTimer = jumpCooldown;


        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            Vector3 dashDirection = movement.normalized;

            rb.linearVelocity = new Vector3 (dashDirection.x * dashForce, rb.linearVelocity.y, dashDirection.z * dashForce);
        }
    }
}
