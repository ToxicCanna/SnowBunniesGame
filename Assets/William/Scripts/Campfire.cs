using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //Have manager tell playerstatmanager to refill warmth. 
            Debug.Log("refill warmth here");
            PlayerStatsManager.Instance.SetWarmthToMax();
        }
    }
}
