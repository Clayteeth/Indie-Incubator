using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float rotationSpeed = 30f; // Degrees per second
    public Vector3 rotationAngle;

    private Quaternion targetRotation;
    bool isClosed = true;
    bool isRotating = false;

    void Start()
    {
        targetRotation = transform.rotation; // Set default target
    }

    void Update()
    {
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }
    }

    public void PlayerInteract()
    {
        isClosed = !isClosed;
        isRotating = true;

        if (isClosed)
            targetRotation = transform.rotation * Quaternion.Euler(rotationAngle);
        else
            targetRotation = transform.rotation * Quaternion.Euler(-rotationAngle);
    }
}
