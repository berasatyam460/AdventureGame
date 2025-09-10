using UnityEngine;
using System.Collections.Generic;

public class Interactor : MonoBehaviour
{
    [Header("Sphere Cast Settings")]
    public float sphereRadius = 2f;
    public LayerMask interactableLayer;

    [Header("Raycast Settings")]
    public Transform rayOrigin;
    public float rayDistance = 5f;

    [Header("Input Settings")]
    public KeyCode interactKey = KeyCode.E;
    [Range(0.1f,3f)]
    public float holdTimeMultiplier = 1f;

    private List<IInteractable> currentSphereInteractables = new List<IInteractable>();
    private IInteractable currentRayInteractable;
    private float holdTimer = 0f;
    private bool isHolding = false;

    void Update()
    {
        PerformSphereCheck();
        PerformRayCheck();
        HandleInteractionInput();
    }

    void PerformSphereCheck()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, sphereRadius, interactableLayer);

        // Show pointer for current
        List<IInteractable> newDetected = new List<IInteractable>();
        foreach (var col in hits)
        {
            IInteractable interactable = col.GetComponent<IInteractable>();
            if (interactable != null)
            {
                newDetected.Add(interactable);
                if (!currentSphereInteractables.Contains(interactable))
                {
                    interactable.ShowPointer();
                }
            }
        }

        // Hide pointer for those no longer in range
        foreach (var old in currentSphereInteractables)
        {
            if (!newDetected.Contains(old))
            {
                old.HidePointer();
            }
        }

        currentSphereInteractables = newDetected;
    }

    void PerformRayCheck()
    {
        Ray ray = new Ray(rayOrigin.position, rayOrigin.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, interactableLayer))
        {
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (currentRayInteractable != interactable)
                {
                    currentRayInteractable?.UnHover();
                    currentRayInteractable = interactable;
                    currentRayInteractable.Hover();
                }
                return;
            }
        }

        if (currentRayInteractable != null)
        {
            currentRayInteractable.UnHover();
            currentRayInteractable = null;
        }
    }

    void HandleInteractionInput()
    {
        if (currentRayInteractable == null)
            return;

        E_Interact_Type type = currentRayInteractable.GetInteractType();

        if (type == E_Interact_Type.Press)
        {
            if (Input.GetKeyDown(interactKey))
            {
                currentRayInteractable.Interact(this.gameObject);
            }
        }
        else if (type == E_Interact_Type.Hold)
        {
            if (Input.GetKey(interactKey))
            {
                isHolding = true;
                holdTimer += holdTimeMultiplier * Time.deltaTime;
                float holdProgress = Mathf.Clamp01(holdTimer / 1f); // Customize max hold duration
                currentRayInteractable.PushInteractStatus(holdProgress);
            }
            else if (isHolding)
            {
                isHolding = false;
                holdTimer = 0f;
                currentRayInteractable.PushInteractStatus(0f); // Reset hold status
            }
        }
    }
}
