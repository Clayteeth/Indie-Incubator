using UnityEngine;

public class GasPushBack : MonoBehaviour
{
    public float moveAmount = 5f;
    public float speed = 2f;

    private Vector3 startPos;
    private Vector3 targetPos;

    private bool isMoving;
    private bool goingForward = true;

    void Start()
    {
        startPos = transform.position;
        targetPos = new Vector3(transform.position.x + moveAmount, transform.position.y, transform.position.z);
    }

    void Update()
    {
        if (isMoving == true)
        {
            if (goingForward == true)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, targetPos) < 0.01f)
                {
                    goingForward = false;
                }
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, startPos, speed * Time.deltaTime);

                if (Vector3.Distance(transform.position, startPos) < 0.01f)
                {
                    isMoving = false;
                    goingForward = true;
                }
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (isMoving == false)
            {
                isMoving = true;
            }
        }
    }
}