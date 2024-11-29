using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendCarry : MonoBehaviour
{
    [SerializeField] private Transform _grabPosition;

    public void Lift(GameObject target)
    {
        Debug.Log("Lift");
        if (_grabPosition.childCount == 0)
        {
            if (target.GetComponent<RegularObj>())
            {
                target.transform.SetParent(_grabPosition);
            }
            else if (target.GetComponent<Food>())
            {
                target.transform.SetParent(_grabPosition);
            }
        }
        
    }    

    public void Release()
    {
        Debug.Log("Release");
        if (_grabPosition.childCount > 0)
        {
            _grabPosition.GetChild(0).SetParent(null);
        }
        
    }
}
