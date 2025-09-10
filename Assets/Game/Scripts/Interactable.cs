using UnityEngine;

public class Interactable : MonoBehaviour, IInteract
{
    public void DoInteract(GameObject gameObject)
    {
        Debug.Log("Interact");
    }


}
