using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendStateMachine : BaseStateMachine
{
    private FriendFollow _friendFollowState;

    public FriendFollow FriendFollowState => _friendFollowState;


    //private FriendMovement _friendMovement;

    //public FriendMovement FriendMovement => _friendMovement;

    private void Awake()
    {
        _friendFollowState = new FriendFollow(this);
    }
        private void Start()
    {
        //SetState(_friendFollowState);
    }
}
