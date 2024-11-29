using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendFoundTargetState : BaseState
{
    private FriendStateMachine _stateMachine;
    public FriendFoundTargetState(FriendStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public override void EnterState()
    {
        _stateMachine.FriendMovement.MoveTo();
    }

    public override void ExitState()
    {

    }

    public override void UpdateState()
    {
        if(_stateMachine.FriendMovement.AgentReachedDestination())
        {
            InteractAndReturn();
        }
    }

    private void InteractAndReturn()
    {
        _stateMachine.FriendCarry.Lift(_stateMachine.FriendMovement.GetMoveToTarget().parent.gameObject);
        _stateMachine.SetState(_stateMachine.FriendReturnState);
    }

}
