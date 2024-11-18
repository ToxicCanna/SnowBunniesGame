using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : PickedUpController, IInteractable
{
    public void Interact()
    {
        if (!isPickedUp)
        {
            PickUp(gameObject);
            Debug.Log(isPickedUp);
        }
    }
    private void Update()
    {
        if (isPickedUp == true && Input.GetMouseButtonDown(0))
        {
            Release(gameObject);
        }
    }
}
