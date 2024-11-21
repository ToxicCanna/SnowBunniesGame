using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Food : UsingItem, IUsingItem
{
    public void UseItem()
    {
        Debug.Log("Try use it");
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
            Debug.Log("I have eaten something");
        }
    }
}
