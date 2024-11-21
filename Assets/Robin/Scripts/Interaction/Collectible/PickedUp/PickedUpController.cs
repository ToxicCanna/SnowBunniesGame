using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PickedUpController : MonoBehaviour
{
    [SerializeField] protected Transform grabPos;
    protected bool isPickedUp = false;

    protected void PickUp(GameObject grabbedObject)
    {
        Debug.Log("grab");
        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        grabbedObject.transform.position = grabPos.position;
        grabbedObject.transform.SetParent(grabPos);
        isPickedUp = true;
    }

    protected void Release(GameObject grabbedObject)
    {
        Debug.Log("release");
        grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        grabbedObject.transform.SetParent(null);
        grabbedObject = null;
        isPickedUp = false;
    }

}
