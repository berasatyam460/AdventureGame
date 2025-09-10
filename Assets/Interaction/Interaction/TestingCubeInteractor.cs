using System.Collections;
using UnityEngine;

public class TestingCubeInteractor : InteractableBase
{
    [SerializeField] int interactionNo;
    public override void Interact(GameObject interctingObject)
    {
        base.Interact(interctingObject);
        StartCoroutine(PlayAnim());


    }

    IEnumerator PlayAnim()
    {
        ActionManger.AnimationType?.Invoke(true, interactionNo);
        yield return new WaitForSeconds(0.1f);
        ActionManger.AnimationType?.Invoke(false, interactionNo);
    }
}
