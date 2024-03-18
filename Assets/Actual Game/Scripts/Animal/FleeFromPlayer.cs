using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FleeFromPlayer : MonoBehaviour
{
    private NavMeshAgent _navAgent;
    public GameObject player;
    public float fleeDistance = 5.0f;

    void Start()
    {
        _navAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        Debug.Log("Distance: " + distance);

        if (distance < fleeDistance)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 newPos = transform.position + dirToPlayer;
            _navAgent.SetDestination(newPos);
        }
    }
}
