using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FriendMovement : MonoBehaviour
{
    [SerializeField] private Transform[] patrollingTargets;
    // Hold the current target

    private Transform _currentTarget;

    private NavMeshAgent _agent;

    private bool _isPatrolling = true;

    private int _currentTargetNum = 0;

    private bool _patrollingAscending = true;

    [SerializeField] private Transform _defaultFollowTarget;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        FollowTarget(_defaultFollowTarget);

    }

    private void FixedUpdate()
    {
        UpdatePatrolling();
        UpdateTargetFollow();
    }

    public void SetPatrolling(bool value)
    {
        _isPatrolling = value;
    }

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
        _currentTarget = target;
    }

    private void UpdatePatrolling()
    {
        if (!_isPatrolling) return;

        if (_agent.remainingDistance <= 0.5f)
        {
            ChooseNextTarget();
        }

    }
    private void UpdateTargetFollow()
    {
        if (_isPatrolling) return;

        _agent.SetDestination(_currentTarget.position);
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
}
