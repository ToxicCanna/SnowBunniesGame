using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickUp : PickedUpController, IInteractable
{
    public void Interact()
    {
        if (!isPickedUp)
        {
            PickUp(gameObject);
            Debug.Log(isPickedUp);
        }
    }
    protected void PutDownObj()
    {
        if (isPickedUp && Input.GetMouseButtonDown(0))
        {
            Release(gameObject);
        }
    }
}
