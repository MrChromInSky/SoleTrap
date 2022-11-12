using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.Animations;
using UnityEngine;
using System;

public class AIController : MonoBehaviour
{
    public float sanitylvl = 100;
    public Transform destiation;
    public Transform destiationBackUp;
    public Transform home;

    private NavMeshAgent agent;
    private Animator anim;
    private GameController gameC;

    public Room[] rooms;

    public bool boo = false;
    private float timerBo = 2;
    void Start()
    {
        anim = transform.GetComponent<Animator>();
        agent = transform.GetComponent<NavMeshAgent>();
        gameC = FindObjectOfType<GameController>();
        gameC.howManyHumans += 1;
    }

    void Update()
    {
        if (destiation == null)
        {
            FindDestinatin();
        }

        else if (transform.position.x != destiation.position.x || transform.position.z != destiation.position.z)
        {
            agent.SetDestination(destiation.position);
            anim.SetBool("walking", true);
        }
        else
        {
            if (destiation.GetComponent<Room>())
            {
                if (destiation.GetComponent<Room>().WorkingLvl >= 100)
                {
                    destiation = null;
                    anim.SetBool("working", false);

                }
                else
                {
                    anim.SetBool("walking", false);
                    destiation.GetComponent<Room>().IsWorkig = true;
                    anim.SetBool("working", true);
                }
            }
        }

        //sanity
        if (sanitylvl <= 0)
        {
            destiation = home;
            anim.SetBool("sprint", true);
            agent.speed = 8;
            if (transform.position.x == home.position.x || transform.position.z == home.position.z)
            {
                gameC.howManyHumans -= 1;
                Destroy(gameObject);
            }
        }

        if(boo)
        {
            timerBo -= 0.5f * Time.deltaTime;
            if(timerBo <= 0)
            {
                destiation = destiationBackUp;
                agent.Resume();
                boo = false;
            }
        }
    }

    private void FindDestinatin()
    {
        float intrestinglvl = 0;
        int number = 0;
        for (int i = 0; i < rooms.Length; i++)
        {
            if (rooms[i].IsEmpty && rooms[i].WorkingLvl < 100)
            {
                if (intrestinglvl <= rooms[i].Intresting)
                {
                    intrestinglvl = rooms[i].Intresting;
                    number = i;
                }
            }
        }
        if (rooms[number].IsEmpty)
        {
            destiation = rooms[number].transform;
            rooms[number].IsEmpty = false;
        }
    }

    public void JumpScare(float sanityPoits)
    {
        sanitylvl -= sanityPoits;
        boo = true;
        timerBo = 3;
        anim.SetTrigger("boo");
        destiationBackUp = destiation;
        destiation = null;
        agent.Stop();
        if(sanitylvl <= 0)
        {
            agent.Resume();
            boo = false;
        }
    }
}
