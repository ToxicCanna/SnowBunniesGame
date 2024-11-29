using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Food : UsingItem, IUsingItem
{
    [SerializeField] private float foodValue = 0.25f;
    public void UseItem()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
            Debug.Log("I have eaten something");
            PlayerStatsManager.Instance.AddValueToHunger(foodValue);
        }
    }
}
