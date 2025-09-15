using System.Collections;
using UnityEngine;
public class GrabTorch : TestingCubeInteractor
{

    [SerializeField] int layerIndex;
    private float transionSpeed = 0.3f;
    void OnEnable()
    {
        ActionManger.InteractAnimFinish += OnInteractFinish;
    }
    void OnDisable()
    {
        ActionManger.InteractAnimFinish -= OnInteractFinish;
    }
    public override void OnInteractFinish()
    {
        base.OnInteractFinish();
        StartCoroutine(SmoothLayerWeight(1));

    }

    private IEnumerator SmoothLayerWeight(float targetWeight)
    {
        float initialWeight = playerAnimator.GetLayerWeight(layerIndex);
        float elapsed = 0f;

        while (elapsed < transionSpeed)
        {
            elapsed += Time.deltaTime;
            float newWeight = Mathf.Lerp(initialWeight, targetWeight, elapsed / transionSpeed);
            playerAnimator.SetLayerWeight(layerIndex, newWeight);
            yield return null;
        }

        playerAnimator.SetLayerWeight(layerIndex, targetWeight);
    }
}


