using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Food : UsingItem, IUsingItem
{
    public void UseItem()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
            Debug.Log("I have eaten something");
            PlayerStatsManager.Instance.AddValueToHunger(0.25f);
        }
    }
}
