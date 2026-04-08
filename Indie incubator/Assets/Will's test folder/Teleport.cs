using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float teleportHeight = 25f;
    public float duration = 5f;

    private bool isTeleported = false;
    Rigidbody rb;

    public GameObject vfx;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        vfx.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isTeleported)
        {
            StartCoroutine(Teleporting());
        }
    }

    IEnumerator Teleporting()
    {
        isTeleported = true;
        vfx.SetActive(true);

        rb.position += new Vector3(0f, teleportHeight, 0f);
        rb.linearVelocity = Vector3.zero;
        Debug.Log("Teleport Up!");

        yield return new WaitForSeconds(duration);

        rb.position -= new Vector3(0f, teleportHeight, 0f);
        rb.linearVelocity = Vector3.zero;
        Debug.Log("Teleport Down!");

        isTeleported = false;
        vfx.SetActive(false);
    }
}
