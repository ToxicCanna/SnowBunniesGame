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

    private FriendCarry _friendCarry;

    public FriendCarry FriendCarry => _friendCarry;

    private FriendFind _friendFind;
    public FriendFind FriendFind => _friendFind;

    private void Awake()
    {
        _friendFollowState = new FriendFollow(this);
        _friendTalkState = new FriendTalkState(this);
        _friendSearchState = new FriendSearchState(this);
        _friendFoundTargetState = new FriendFoundTargetState(this);
        _friendReturnState = new FriendReturnState(this);

        _friendMovement = GetComponent<FriendMovement>();
        _friendCarry = GetComponent<FriendCarry>();
        _friendFind = GetComponentInChildren<FriendFind>();
    }
    private void Start()
    {
        SetState(_friendFollowState);
    }

    public void JumpToTalkState()
    {
        SetState(_friendTalkState);
    }
    public void JumpToSearchState()
    {
        SetState(_friendSearchState);
    }

    public void JumpToFoundTargetState()
    {
        SetState(_friendFoundTargetState);
    }

    

}
