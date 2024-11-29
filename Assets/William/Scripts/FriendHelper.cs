using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendHelper : MonoBehaviour
{
    [SerializeField] private FriendStateMachine[] _friends;
    private FriendStateMachine _activeFriend;
    [SerializeField] private Button friendTalkButton;
    [SerializeField] private GameObject buttonUI;
    [SerializeField] private GameObject buttonBunny;
    [SerializeField] private GameObject buttonDecor;

    public void FirstInLineOpenUI()
    {
        foreach (FriendStateMachine friend in _friends)
        {
            if (friend.FriendMovement.GetFollowTarget().CompareTag("Player"))
            {
                _activeFriend = friend;
                _activeFriend.JumpToTalkState();
                friendTalkButton.enabled = false;
                buttonUI.SetActive(true);
                buttonBunny.SetActive(false);
                buttonDecor.SetActive(true);
            }
        }
    }

    public void FindAndInteract(string tag)
    {
        friendTalkButton.enabled = true;
        buttonUI.SetActive(false);              
        buttonBunny.SetActive(true);
        buttonDecor.SetActive(false);
        _activeFriend.FriendFind.SetTag(tag);
        _activeFriend.JumpToSearchState();
    }
}
