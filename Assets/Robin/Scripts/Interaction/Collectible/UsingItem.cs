using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingItem : PickUp
{
    private void Update()
    {
        PutDownObj();

        if (grabPos.GetComponentInChildren<IUsingItem>() != null)
        {
            IUsingItem iUsingItem = grabPos.GetComponentInChildren<IUsingItem>();
            iUsingItem.UseItem();
        }
    }
}
