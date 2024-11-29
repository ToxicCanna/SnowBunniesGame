using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendMovement : MonoBehaviour
{
    [SerializeField] private Transform[] patrollingTargets;
    // Hold the current target

    private Transform _currentTarget;

    private Transform _moveToTarget;

    private NavMeshAgent _agent;

    private bool _isPatrolling = true;

    private bool _isMovingToTarget = false;

    private int _currentTargetNum = 0;

    private bool _patrollingAscending = true;

    [SerializeField] private Transform _defaultFollowTarget;
   // [SerializeField] private Transform _firstInQueue;
    [SerializeField] private Transform _lastInQueue;

    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _talkLocationTransform;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        FollowTarget(_defaultFollowTarget);

    }

    private void FixedUpdate()
    {
        UpdateMoveToTarget();
        UpdatePatrolling();
        UpdateTargetFollow();
    }

    public void SetPatrolling(bool value)
    {
        _isPatrolling = value;
    }

    public void StartPatrolling()
    {
        SetPatrolling(true);
        _agent.isStopped = false;
        _isMovingToTarget = false;
    }

    public bool IsPatrolling()
    { return _isPatrolling; }

    public void StopMovement()
    {
        _agent.isStopped = true;
    }

    public void StartMovement()
    {
        _agent.isStopped = false;
    }

    public void FollowTarget(Transform target)
    {
        _isPatrolling = false;
        _isMovingToTarget = false;
        _currentTarget = target;
        _agent.stoppingDistance = 3f;
    }

    private void UpdatePatrolling()
    {
        if (!_isPatrolling) return;
        if (_isMovingToTarget) return;

        if (_agent.remainingDistance <= 3f)
        {
            ChooseNextTarget();
        }

    }
    private void UpdateTargetFollow()
    {
        if (_isPatrolling) return;
        if (_isMovingToTarget) return;
        _agent.SetDestination(_currentTarget.position);
    }

    private void UpdateMoveToTarget()
    {
        if (!_isMovingToTarget) return;
        //not setting destination here because we only need to set it once when we call this. 
    }

    private void ChooseNextTarget()
    {
        _currentTarget = patrollingTargets[_currentTargetNum];
        _agent.SetDestination(_currentTarget.position);
        if (_patrollingAscending)
        {
            _currentTargetNum++;
            if (_currentTargetNum >= patrollingTargets.Length)
            {
                _currentTargetNum = 0;
            }
        }
        else {
            _currentTargetNum--;
            if (_currentTargetNum < 0)
            {
                _currentTargetNum = patrollingTargets.Length - 1;
            }
        }
        
    }

    public void UpdateQueue(Transform lastInQueueTransform)
    {
        _lastInQueue = lastInQueueTransform;
    }

    public Transform GetLastInQueue()
    {
        return _lastInQueue;
    }

 /*   public Transform GetFirstInQueue()
    {
        return _firstInQueue;
    }*/

    public Transform GetPlayerPosition()
    {
        return _playerTransform;
    }

    public Transform GetTalkPosition()
    {
        return _talkLocationTransform;
    }

    public void SetMoveToTarget(Transform target)
    {
        _moveToTarget = target;
    }

    public Transform GetMoveToTarget()
    {
        return _moveToTarget;
    }
    public void MoveTo()
    {
        _isMovingToTarget = true;
        _agent.SetDestination(_moveToTarget.position);
        _agent.stoppingDistance = 0;
    }

    public void FinishMoveTo()
    {
        _isMovingToTarget = false;
        _agent.SetDestination(_currentTarget.position);
        _agent.stoppingDistance = 3;
    }
    public void TurnToward(Transform target)
    { 
        transform.rotation = Quaternion.LookRotation((target.position - transform.position).normalized);
    }

    public bool AgentReachedDestination()
    {
        // Check if we've reached the destination. from https://discussions.unity.com/t/how-can-i-tell-when-a-navmeshagent-has-reached-its-destination/52403/5
        if (!_agent.pathPending)
        {
            if (_agent.remainingDistance <= _agent.stoppingDistance)
            {
                if (!_agent.hasPath || _agent.velocity.sqrMagnitude == 0f)
                {
                    return true;
                }
            }
        }
        return false;
    }

    public Transform GetFollowTarget()
    {
        return _currentTarget;
    }
}
