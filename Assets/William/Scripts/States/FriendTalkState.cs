using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendTalkState : BaseState
{
    //this state happens when player press a ui or a button
    private FriendStateMachine _stateMachine;
    public FriendTalkState(FriendStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public override void EnterState()
    {
        _stateMachine.FriendMovement.SetMoveToTarget(_stateMachine.FriendMovement.GetTalkPosition());
        _stateMachine.FriendMovement.MoveTo();
    }

    public override void ExitState()
    {
        _stateMachine.FriendMovement.FinishMoveTo();
        _stateMachine.FriendMovement.StartMovement();
    }

    public override void UpdateState()
    {
        if (_stateMachine.FriendMovement.AgentReachedDestination())
        {
            _stateMachine.FriendMovement.TurnToward(_stateMachine.FriendMovement.GetPlayerPosition());
            _stateMachine.FriendMovement.StopMovement();
        }
    }

}
