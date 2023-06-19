using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    NavMeshAgent agent;
    public GameObject Target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }


    void Update()
    {
        agent.SetDestination(Target.transform.position);
    }
}
