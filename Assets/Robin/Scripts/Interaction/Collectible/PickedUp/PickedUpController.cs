using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class PickedUpController : MonoBehaviour
{
    [SerializeField] private float switchSwapTime = 0.05f;
    [SerializeField] private string grabName;

    protected bool isPickedUp = false;

    public string getName()
    {
        return grabName;
    }
    protected void PickUp(GameObject grabbedObject)
    {
        Debug.Log("grab");
        Debug.Log(grabName);

        grabbedObject.GetComponent<Rigidbody>().isKinematic = true;
        grabbedObject.transform.position = GrabPos.Instance.grabPos.position;
        grabbedObject.transform.SetParent(GrabPos.Instance.grabPos);
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
