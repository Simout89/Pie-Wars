using System;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class UnitModel : Entity
{
    [SerializeField] protected int Speed;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    public void GoTo(Vector3 coordinates)
    {
        _agent.destination = coordinates;
    }
}
