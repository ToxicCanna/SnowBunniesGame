using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollectible : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        Debug.Log("Test");
    }
}
