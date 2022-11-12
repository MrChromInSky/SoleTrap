using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine;

public class AIController : MonoBehaviour
{

    public Transform destiation;

    private NavMeshAgent agent;
    private Animator anim;

    void Start()
    {
        agent = transform.GetComponent<NavMeshAgent>();
        anim = transform.GetComponent<Animator>();
    }

    void Update()
    {
        if (transform.position.x != destiation.position.x || transform.position.z != destiation.position.z)
        {
            agent.SetDestination(destiation.position);
            anim.SetBool("walking", true);
        }
        else
            anim.SetBool("walking", false);
    }
}
