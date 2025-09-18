using System.Collections;
using UnityEngine;
public class GrabTorch : TestingCubeInteractor
{
    [SerializeField] QuestClass questClass;
    [SerializeField] int layerIndex;
    private float transionSpeed = 0.3f;
    [SerializeField] InteractionTypes interactionTypes;
    void OnEnable()
    {
        ActionManger.InteractAnimFinish += OnInteractFinish;
    }
    void OnDisable()
    {
        ActionManger.InteractAnimFinish -= OnInteractFinish;
    }
    public override void OnInteractFinish(InteractionTypes interactionTypes)
    {
        base.OnInteractFinish(interactionTypes);
        if (this.interactionTypes == interactionTypes)
        {
            StartCoroutine(SmoothLayerWeight(1));

        }



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
        ActionManger.UpdateQuestData?.Invoke(questClass.questData, questClass.amountToChange, questClass.questNo);
    }
}


