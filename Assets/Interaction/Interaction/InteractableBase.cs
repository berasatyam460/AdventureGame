using UnityEngine;

public abstract class InteractableBase : MonoBehaviour, IInteractable
{
    [Header("Pointer UI")]
    [SerializeField] private InteractPointerWidget pointerWidget;

    [Header("Interaction Info")]
    [SerializeField] private string interactKey = "E";
    [SerializeField] private string headerText = "Interact";
    [SerializeField][TextArea] private string toolTipText = "";
    [SerializeField] private E_Interact_Type interactionType = E_Interact_Type.Press;

    private bool isHovered = false;
    private bool hasInteracted = false;  // NEW: Tracks if interaction happened

    public virtual void ShowPointer()
    {
        if (hasInteracted) return;  // Prevent showing pointer after interaction

        if (pointerWidget == null)
        {
            pointerWidget = GetComponentInChildren<InteractPointerWidget>();
            if (pointerWidget == null) return;
        }
        pointerWidget.ShowPointerWidget();
    }

    public virtual void HidePointer()
    {
        if (pointerWidget == null) return;
        pointerWidget.HidePointerWidget();
    }

    public virtual void Hover()
    {
        if (hasInteracted) return;  // Prevent hover UI after interaction
        if (pointerWidget == null || isHovered) return;

        pointerWidget.ShowFullPanelStatus(true, interactKey, headerText, toolTipText);
        isHovered = true;
    }

    public virtual void UnHover()
    {
        if (pointerWidget == null || !isHovered) return;

        pointerWidget.ShowFullPanelStatus(false, "", "", "");
        isHovered = false;
    }

    public virtual void Interact(GameObject interctingObject)
    {
        if (hasInteracted) return;  // Prevent multiple interactions

        hasInteracted = true;  // Mark as interacted
        HidePointer();
        // Interaction logic to be overridden in derived classes
    }

    public virtual void PushInteractStatus(float status)
    {
        if (pointerWidget == null) return;
        pointerWidget.SetFillAmount(status);
    }

    public virtual E_Interact_Type GetInteractType()
    {
        return interactionType;
    }

    protected void UpdateTooltipText(string newText)
    {
        toolTipText = newText;
        if (isHovered)
        {
            pointerWidget.ShowFullPanelStatus(true, interactKey, headerText, toolTipText);
        }
    }

    // Optional: Allow external reset of interaction
    public void ResetInteraction()
    {
        hasInteracted = false;
    }
}
