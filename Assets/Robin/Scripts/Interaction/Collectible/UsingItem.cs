using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class UsingItem : PickUp
{
    private void Update()
    {
        PutDownObj();

        if (GrabPos.Instance.grabPos.GetComponentInChildren<IUsingItem>() != null)
        {
            IUsingItem iUsingItem = GrabPos.Instance.grabPos.GetComponentInChildren<IUsingItem>();
            iUsingItem.UseItem();
        }
    }
}
