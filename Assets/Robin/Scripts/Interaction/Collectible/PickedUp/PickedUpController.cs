using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PickedUpController : MonoBehaviour
{
    [SerializeField] protected Transform grabPos;
    [SerializeField] private float switchSwapTime = 0.05f;
    protected bool isPickedUp = false;

    protected void PickUp(GameObject grabbedObject)
    {
        Debug.Log("grab");
        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        grabbedObject.transform.position = grabPos.position;
        grabbedObject.transform.SetParent(grabPos);
        StartCoroutine(CheckSwap());
    }

    protected void Release(GameObject grabbedObject)
    {
        Debug.Log("release");
        grabbedObject.GetComponent<Rigidbody>().isKinematic = false;
        grabbedObject.transform.SetParent(null);
        StartCoroutine(CheckSwap());
    }
    IEnumerator CheckSwap()
    {
        yield return new WaitForSeconds(switchSwapTime);
        isPickedUp ^= true;
        Debug.Log(isPickedUp);
    }
}
