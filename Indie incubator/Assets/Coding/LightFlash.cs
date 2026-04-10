using UnityEngine;

public class LightFlash : MonoBehaviour
{
    public Light areaLight;
    public float speed = 2f;
    public float minIntensity = 0f;
    public float maxIntensity = 5f;

    void Update()
    {
        float t = Mathf.PingPong(Time.time * speed, 1f);
        areaLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, t);
    }
}