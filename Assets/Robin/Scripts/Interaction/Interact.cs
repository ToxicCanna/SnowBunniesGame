using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;

public class Interact : MonoBehaviour
{
    [SerializeField] private float interactDistance = 2.0f;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Act();
        }
    }

    private void Act()
    {
        Ray ray = new Ray(gameObject.transform.position, gameObject.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, interactDistance))
        {
            StartInteract(hit);
        }
    }

    private void StartInteract(RaycastHit hit)
    {
        if (hit.collider.gameObject.GetComponent<IInteractable>() != null)
        {
            IInteractable iInteractable = hit.collider.gameObject.GetComponent<IInteractable>();
            iInteractable.Interact();
        }
    }
}
