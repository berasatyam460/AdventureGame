using UnityEngine;

public class FireTorchEffect : MonoBehaviour
{
    public Light torchLight;
    public Texture fireCookieTexture;

    public float minIntensity = 1.5f;
    public float maxIntensity = 2.5f;
    public float flickerSpeed = 0.1f;

    private float targetIntensity;
    private float flickerTimer = 0f;

    void Start()
    {
        if (torchLight != null && fireCookieTexture != null)
        {
            torchLight.cookie = fireCookieTexture;
            torchLight.cookieSize = 5f;
        }
    }

    void Update()
    {
        flickerTimer += Time.deltaTime;

        if (flickerTimer >= flickerSpeed)
        {
            flickerTimer = 0f;
            targetIntensity = Random.Range(minIntensity, maxIntensity);
        }

        torchLight.intensity = Mathf.Lerp(torchLight.intensity, targetIntensity, Time.deltaTime * 5f);
    }
}
