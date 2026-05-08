using JetBrains.Annotations;
using UnityEngine;

public class Look_At : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    public Transform faceNode;
    // Update is called once per frame
    void LateUpdate()
    {
        transform.LookAt(faceNode);
    }
}
