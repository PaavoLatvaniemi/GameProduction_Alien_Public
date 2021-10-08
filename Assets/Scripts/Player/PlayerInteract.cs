using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] float interactDistance;
    [Header("Indicator")]
    [SerializeField] bool showIndicator;
    [SerializeField] InteractIndicator interactIndicator;

    Camera mainCamera;

    void Awake()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact")) Interact();
    }

    void FixedUpdate()
    {
        if (!showIndicator || interactIndicator == null) return;

        IInteractable[] interactables = GetInteractableWithRaycast();
        if (interactables != null)
        {
            if (!interactIndicator.IsActive) 
            {
                interactIndicator.ShowIndicator();
                if(interactables[0].InteractableName != "")
                {
                    interactIndicator.SetActionText(interactables[0].InteractableName);
                }
            }
            return;
        }

        if (interactIndicator.IsActive) 
        {
            interactIndicator.HideIndicator();
            interactIndicator.SetActionText("");
        }
    }

    void Interact()
    {
        IInteractable[] interactables = GetInteractableWithRaycast();
        if (interactables != null)
            foreach (IInteractable interactable in interactables)
                interactable.OnInteract();
    }

    IInteractable[] GetInteractableWithRaycast()
    {
        RaycastHit hit;
        Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.TransformDirection(Vector3.forward));
        if (Physics.Raycast(ray, out hit, interactDistance, ~LayerMask.GetMask("Player")))
        {
            IInteractable[] interactables;
            interactables = hit.transform.GetComponentsInParent<IInteractable>();
            if (interactables != null && interactables.Length > 0) return interactables;
        }
        return null;
    }
}
