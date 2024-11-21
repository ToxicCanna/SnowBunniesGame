using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingItem : PickedUpController
{
    private void Update()
    {
        if (grabPos.GetComponentInChildren<IUsingItem>() != null)
        {
            IUsingItem iUsingItem = grabPos.GetComponentInChildren<IUsingItem>();
            iUsingItem.UseItem();
        }
    }
}
