using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 200f;
    public Transform playerBody;
    private Rigidbody playerRb;
    float xRotation = 0f;
    public float cutsceneDuration = 3f;

    void Start()
    {
        playerRb = playerBody.GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        // Skip mouse control during cutscene
        if (Time.timeSinceLevelLoad < cutsceneDuration)
            return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        Quaternion deltaRotation = Quaternion.Euler(0f, mouseX, 0f);
        playerRb.MoveRotation(playerRb.rotation * deltaRotation);
        //playerBody.Rotate(Vector3.up * mouseX);
    }

    void OnEnable()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
