using System.Collections;
using UnityEngine;

public class FireTorchEffect : MonoBehaviour
{
    [SerializeField] Light torchLight;
    [SerializeField] Texture fireCookieTexture;

    [SerializeField] float minIntensity = 1.5f;
    [SerializeField] float maxIntensity = 2.5f;
    [SerializeField] float flickerSpeed = 0.1f;

    private float targetIntensity;
    private float flickerTimer = 0f;

    private bool canLightGlowing = false;

    void Start()
    {
        if (torchLight != null && fireCookieTexture != null)
        {
            torchLight.cookie = fireCookieTexture;
            torchLight.cookieSize = 5f;
            canLightGlowing = true;

            StartCoroutine(GlowLight());
        }
    }



    IEnumerator GlowLight()
    {
        while (canLightGlowing)
        {

            // Pick a new random intensity
            targetIntensity = Random.Range(minIntensity, maxIntensity);

            // Smoothly move toward target intensity
            float elapsed = 0f;
            float startIntensity = torchLight.intensity;

            while (elapsed < flickerSpeed)
            {
                elapsed += Time.deltaTime;
                torchLight.intensity = Mathf.Lerp(startIntensity, targetIntensity, elapsed / flickerSpeed);
                yield return null; // wait for next frame
            }

            yield return null;
        }
    }
}
