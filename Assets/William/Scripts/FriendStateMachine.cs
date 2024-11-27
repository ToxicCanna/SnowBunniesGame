using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendStateMachine : BaseStateMachine
{
    private FriendFollow _friendFollowState;

    public FriendFollow FriendFollowState => _friendFollowState;

    private FriendTalkState _friendTalkState;
    public FriendTalkState FriendTalkState => _friendTalkState;

    private FriendSearchState _friendSearchState;
    public FriendSearchState FriendSearchState => _friendSearchState;

    private FriendFoundTargetState _friendFoundTargetState;
    public FriendFoundTargetState FriendFoundTargetState => _friendFoundTargetState;
    
    private FriendReturnState _friendReturnState;
    public FriendReturnState FriendReturnState => _friendReturnState;


    private FriendMovement _friendMovement;

    public FriendMovement FriendMovement => _friendMovement;

    private void Awake()
    {
        _friendFollowState = new FriendFollow(this);
    }
    private void Start()
    {
        SetState(_friendFollowState);
    }
}
