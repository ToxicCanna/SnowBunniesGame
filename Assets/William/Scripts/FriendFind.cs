using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendFind : MonoBehaviour
{
    private string targetTag;
    [SerializeField] private FriendStateMachine _myStateMachine;
    
    public void SetTag(string tag)
    {
        Debug.Log("FriendFInd set Tag:" + tag);
        targetTag = tag;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_myStateMachine.FriendMovement.IsPatrolling() && other.CompareTag(targetTag))
        {
            _myStateMachine.FriendMovement.SetMoveToTarget(other.transform);
            _myStateMachine.JumpToFoundTargetState();
        }
    }
}
