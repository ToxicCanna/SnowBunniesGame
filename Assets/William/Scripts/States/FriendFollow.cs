using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendFollow : BaseState
{
    private FriendStateMachine _stateMachine;
    public FriendFollow(FriendStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public override void EnterState()
    {
        Debug.Log(_stateMachine.FriendMovement.GetLastInQueue());
       //_stateMachine.FriendMovement.FollowTarget(_stateMachine.FriendMovement.GetLastInQueue());

    }

    public override void ExitState()
    {
        
    }

    public override void UpdateState()
    {
        
    }

}
