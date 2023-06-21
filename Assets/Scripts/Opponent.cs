using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class Opponent : MonoBehaviour
{
    NavMeshAgent agent;
    public float startSpeed = 5f;
    public float boostedSpeed = 8f;
    public Transform startPoint;
    public GameObject speedBoostIcon;
    public GameObject Target;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        transform.position = startPoint.position;
        agent.speed = startSpeed;
    }


    void Update()
    {
        agent.SetDestination(Target.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Obstacle"))
        {
            transform.position = startPoint.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("SpeedBoost"))
        {
            StartCoroutine(SpeedBoostSequence());
        }
        else if(other.CompareTag("Bumper"))
        {
            StartCoroutine(BumperSequence());
        }
    }

    IEnumerator SpeedBoostSequence()
    {

        agent.speed = boostedSpeed;
        speedBoostIcon.SetActive(true);
        yield return new WaitForSeconds(4);
        agent.speed = startSpeed;
        speedBoostIcon.SetActive(false);
    }

    IEnumerator BumperSequence()
    {

        agent.speed = 3;
        yield return new WaitForSeconds(4);
        agent.speed = startSpeed;
    }
}
