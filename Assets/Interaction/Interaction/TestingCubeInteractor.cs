using System.Collections;
using UnityEngine;

public class TestingCubeInteractor : InteractableBase
{
    [SerializeField] int interactionNo;

    public override void Interact(GameObject interctingObject)
    {
        base.Interact(interctingObject);


        ActionManger.headTrackingON?.Invoke(this.transform);


        StartCoroutine(PlayAnim(this.gameObject));
    }

    IEnumerator PlayAnim(GameObject interactableObject)
    {

        ActionManger.AnimationType?.Invoke(true, interactionNo, interactableObject);
        yield return new WaitForSeconds(0.1f);
        ActionManger.AnimationType?.Invoke(false, interactionNo, interactableObject);
        yield return new WaitForSeconds(2f);
        ActionManger.headTrackOff?.Invoke();

    }
}
