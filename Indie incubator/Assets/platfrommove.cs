using UnityEngine;

public class platfrommove : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] Transform[] points;
    [SerializeField] private float cooldownTime = 5f;

    private int targetPoint;
    private bool isMoving;
    private bool canActivate;
    private float timer = 0f;

    void Start()
    {
        transform.position = points[0].position;
        targetPoint = 1;
        isMoving = false;
        canActivate = true;
    }

    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        if (isMoving == false)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, points[targetPoint].position, speed * Time.deltaTime);

        if (transform.position == points[targetPoint].position)
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
            collision.transform.SetParent(transform);

            if (canActivate == true && isMoving == false && timer <= 0f)
            {
                isMoving = true;
                canActivate = false;
                timer = cooldownTime;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);

            if (isMoving == false)
            {
                canActivate = true;
            }
        }
    }
}