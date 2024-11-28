using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendQueue : MonoBehaviour
{
    private GameObject _lastInQueue;
    [SerializeField] private Transform[] _initialFriends;
    private Queue<Transform> _friendQueue;

    private void Start()
    {
        foreach (Transform friend in _initialFriends)
        {
            _friendQueue.Enqueue(friend);
        }
        _lastInQueue = _initialFriends[_initialFriends.Length - 1].gameObject;
    }

    public void FriendReturned(Transform returnedFriend)
    {
        
    }

}
