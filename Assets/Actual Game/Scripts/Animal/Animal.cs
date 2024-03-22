using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public enum AnimalState
{
    Idle,
    Moving,
}
[RequireComponent(typeof(NavMeshAgent))]

public class Animal : MonoBehaviour
{
    [Header("Wander)")]
    public float wanderDistance = 20f; // The distance the animal will wander
    public float walkSpeed = 5f; // The speed the animal will walk
    public float maxWalkTime = 3f; // The maximum time the animal will walk before stopping

    [Header("Idle")]
    public float idleTime = 10f; // The time the animal will be idle

    protected NavMeshAgent navMeshAgent; // The nav mesh agent component so we can separate the animal type
    protected AnimalState currentState = AnimalState.Idle; // The current state of the animal

    private void Start()
    {
        InitializeAnimal();
    }
    
    protected virtual void InitializeAnimal()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = walkSpeed;

        currentState = AnimalState.Idle;
        UpdateState();
    }
    
    protected virtual void UpdateState()
    {
        switch (currentState)
        {
            case AnimalState.Idle:
                HandleIdleState();
                break;
            case AnimalState.Moving:
                HandleMovingState();
                break;
        }
    }
    protected Vector3 GetRandomNavMeshPosition(Vector3 origin, float distance)
    {
        Vector3 randomDirection = Random.insideUnitSphere * distance;
        randomDirection += origin;
        NavMeshHit navMeshHit;

        if (NavMesh.SamplePosition(randomDirection, out navMeshHit, distance, NavMesh.AllAreas))
        {
            return navMeshHit.position;
        }
        else
        {
            return GetRandomNavMeshPosition(origin, distance);
        }
    }
    protected virtual void HandleIdleState()
    {
        StartCoroutine(WaitToMove());
    }
    private IEnumerator WaitToMove()
    {
        float waitTime = Random.Range(idleTime / 2, idleTime * 2);
        yield return new WaitForSeconds(waitTime);

        Vector3 randomDestination = GetRandomNavMeshPosition(transform.position, wanderDistance);

        navMeshAgent.SetDestination(randomDestination);
        SetState(AnimalState.Moving);
    }
    protected virtual void HandleMovingState()
    {
        StartCoroutine(WaitToReachDestination());
    }
    private IEnumerator WaitToReachDestination()
    {
        float startTime = Time.time;

        while (navMeshAgent.pathPending || navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
        {
            if (Time.time - startTime > maxWalkTime)
            {
                navMeshAgent.ResetPath();
                SetState(AnimalState.Idle);
                yield break;
            }

            yield return null;
        }
        SetState(AnimalState.Idle);
    }

    protected void SetState(AnimalState newState)
    {
        if (currentState == newState)
        {
            return;
        }

        currentState = newState;
        OnStateChanged(newState);
    }

    protected virtual void OnStateChanged(AnimalState newState)
    {
        UpdateState();
    }
}
