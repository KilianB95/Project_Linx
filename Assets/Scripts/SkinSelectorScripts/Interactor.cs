using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Interactor : MonoBehaviour
{
    Transform _interactorTransform;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            IInteractable interactable = InteractableObject();
            if (interactable != null)
            {
                interactable.Interact(transform);
            }
        }
    }

    public IInteractable InteractableObject()
    {
        List<IInteractable> interactableList = new List<IInteractable>();
        float interactRange = 2f;
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, interactRange);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent(out IInteractable interactable))
            {
                interactableList.Add(interactable);
            }
        }

        IInteractable closestInteracbtable = null;
        foreach (IInteractable interactable in interactableList)
        {
            if (closestInteracbtable == null)
            {
                closestInteracbtable = interactable;
            }
            else
            {
                if(Vector3.Distance(transform.position, interactable.GetTransform().position) < 
                   Vector3.Distance(transform.position, closestInteracbtable.GetTransform().position))
                {
                    closestInteracbtable = interactable;
                }
            }
        }

        return closestInteracbtable;
    }
}


