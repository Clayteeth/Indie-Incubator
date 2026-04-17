using UnityEngine;

public class platfrommove : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] Transform[] points;

    private int targetPoint;
    private bool isMoving;
    private bool canActivate;

    private Rigidbody rb;

    void Start()
    {
        transform.position = points[0].position;
        targetPoint = 1;
        isMoving = false;
        canActivate = true;

        rb = GetComponent<Rigidbody>();
        rb.position = points[0].position;
    }

    void FixedUpdate()
    {
        if (isMoving == false)
        {
            return;
        }

        Vector3 newPos = Vector3.MoveTowards(rb.position, points[targetPoint].position, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if (rb.position == points[targetPoint].position)
        {
            isMoving = false;

            if (targetPoint == 0)
            {
                targetPoint = 1;
            }
            else
            {
                targetPoint = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (canActivate == true && isMoving == false)
            {
                isMoving = true;
                canActivate = false;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isMoving == false)
            {
                canActivate = true;
            }
        }
    }
}