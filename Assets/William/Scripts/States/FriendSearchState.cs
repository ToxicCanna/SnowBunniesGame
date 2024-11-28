using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendSearchState : BaseState
{
    private FriendStateMachine _stateMachine;
    public FriendSearchState(FriendStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }
    public override void EnterState()
    {
        if (_stateMachine.FriendMovement.GetLastInQueue() == _stateMachine.FriendMovement.transform)
        {
            _stateMachine.FriendMovement.UpdateQueue(_stateMachine.FriendMovement.GetPlayerPosition());
        }
        _stateMachine.FriendMovement.SetPatrolling(true);
    }

    public override void ExitState()
    {
        _stateMachine.FriendMovement.SetPatrolling(false);
    }

    public override void UpdateState()
    {
        //assume when it finds it is on another script.
    }

}
