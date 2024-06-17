using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

[DefaultExecutionOrder(-200)]
[RequireComponent(typeof(NavMeshAgent))]
public class PointsNavigation : MonoBehaviour
{
    [SerializeField] private Transform[] goals;
    [SerializeField] UnityEvent onGoalReached;
    
    private NavMeshAgent _mAgent;
    private int _mNextGoal = 0;

    private void Start()
    {
        _mAgent = GetComponent<NavMeshAgent>();

        _mAgent.SetDestination(goals[0].position);
    }

    public void SetNextGoal()
    {
        if (_mNextGoal >= goals.Length - 1)
        {
            onGoalReached?.Invoke();
            return;
        }
        _mNextGoal++;
        _mAgent.SetDestination(goals[_mNextGoal].position);
    }

    public void StopNavigation()
    {
        _mAgent.isStopped = true;
    }
}
