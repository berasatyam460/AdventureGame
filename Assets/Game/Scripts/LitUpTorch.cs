using UnityEngine;
using System.Collections;

public class LitUpTorch : TestingCubeInteractor
{
    [SerializeField] ParticleSystem fireFx;
    [SerializeField] Light pointFireLight;
    [SerializeField] InteractionTypes interactionTypes;



    [Header("Animaton Effect")]
    [SerializeField] float ignitionDuration = 3f;
    private ParticleSystem.EmissionModule emissionModule;
    void OnEnable()
    {
        ActionManger.InteractAnimFinish += OnInteractFinish;
    }
    void OnDisable()
    {
        ActionManger.InteractAnimFinish -= OnInteractFinish;
    }

    void Awake()
    {
        base.Awake();
        emissionModule = fireFx.emission;

        emissionModule.rateOverTime = 0f;

        fireFx.Pause();
        pointFireLight.enabled = false;
        pointFireLight.intensity = 0;
    }
    public override void OnInteractFinish(InteractionTypes interactionTypes)
    {
        base.OnInteractFinish(interactionTypes);
        if (this.interactionTypes == interactionTypes)
        {
            fireFx.Play();
            pointFireLight.enabled = true;
            Ignite();
        }

    }

    public void Ignite()
    {
        StartCoroutine(IgnitionRoutine());
    }

    private IEnumerator IgnitionRoutine()
    {
        float elapsed = 0f;

        while (elapsed < ignitionDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / ignitionDuration;

            // Smooth interpolation (can use easing curve instead of linear)
            emissionModule.rateOverTime = Mathf.Lerp(0f, 80f, t);

            pointFireLight.intensity = Mathf.Lerp(0f, 5F, t);
            //fireMaterial.SetColor("_EmissionColor", Color.red * Mathf.Lerp(0f, targetEmissionMultiplier, t));

            yield return null;
        }

        // Ensure full intensity at end
        emissionModule.rateOverTime = 50f;
        //fireLight.intensity = targetLightIntensity;
        //fireMaterial.SetColor("_EmissionColor", Color.red * targetEmissionMultiplier);
    }

}


