using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendReturnState : BaseState
{
    private FriendStateMachine _stateMachine;
    public FriendReturnState(FriendStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public override void EnterState()
    {
        _stateMachine.FriendMovement.FollowTarget(_stateMachine.FriendMovement.GetLastInQueue());

    }

    public override void ExitState()
    {
        _stateMachine.FriendMovement.UpdateQueue(_stateMachine.FriendMovement.transform);
        //drop holding item if possible
    }

    public override void UpdateState()
    {
        if(_stateMachine.FriendMovement.AgentReachedDestination())
        {
            ReturnToFollow();
        }
    }

    private void ReturnToFollow()
    {
        _stateMachine.SetState(_stateMachine.FriendFollowState);
    }



}
