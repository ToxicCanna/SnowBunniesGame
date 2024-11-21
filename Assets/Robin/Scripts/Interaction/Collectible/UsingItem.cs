using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingItem : PickUp
{
    private void Update()
    {
        if (isPickedUp && grabPos.GetComponentInChildren<IUsingItem>() != null)
        {
            IUsingItem iUsingItem = grabPos.GetComponentInChildren<IUsingItem>();
            iUsingItem.UseItem();
        }
    }
}
