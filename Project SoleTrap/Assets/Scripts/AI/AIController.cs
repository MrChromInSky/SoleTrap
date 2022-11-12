using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine;

public class AIController : MonoBehaviour
{
    public float sanitylvl = 100;
    public Transform destiation;
    public Transform[] targets;

    private NavMeshAgent agent;
    private Animator anim;
    private GameController gameC;

    void Start()
    {
        anim = transform.GetComponent<Animator>();
        agent = transform.GetComponent<NavMeshAgent>();
        gameC = FindObjectOfType<GameController>();
        gameC.howManyHumans += 1;
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

        if (sanitylvl <= 0)
        {
            destiation = targets[0];
            anim.SetBool("sprint", true);
            agent.speed = 6;
            if(transform.position.x == targets[0].position.x || transform.position.z == targets[0].position.z)
            {
                gameC.howManyHumans -= 1;
                Destroy(gameObject);
            }
        }
    }
}
