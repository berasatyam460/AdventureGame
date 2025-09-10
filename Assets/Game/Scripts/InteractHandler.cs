using Unity.VisualScripting;
using UnityEngine;

public class InteractHandler : MonoBehaviour
{


    [SerializeField] float interactionRange = 2f;
    void OnEnable()
    {
        ActionManger.DoInteract += TryToInteract;
    }
    void OnDisable()
    {
        ActionManger.DoInteract -= TryToInteract;
    }


    private void TryToInteract(bool canInteract)
    {
        if (canInteract)
        {
            DoingInteraction();
        }
    }

    private void DoingInteraction()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactionRange))
        {
            IInteract interactable = hit.collider.GetComponent<IInteract>();
            if (interactable != null)
            {
                Debug.Log("Interact");
                interactable.DoInteract(gameObject);
            }
        }
    }
}



