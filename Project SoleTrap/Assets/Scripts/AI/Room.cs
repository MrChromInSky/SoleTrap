using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public const float WorkSpeed = 0.5f;
    [Header("Properties")]
    [SerializeField] private float workingLvl = 0;
    public float WorkingLvl
    {
        set { workingLvl = value; }
        get { return workingLvl; }
    }
    [SerializeField] private float intresting = 100;
    public float Intresting
    {
        set { intresting = value; }
        get { return intresting; }
    }
    [SerializeField] private bool isEmpty = true;
    public bool IsEmpty
    {
        private set { isEmpty = value; }
        get { return isEmpty; }
    }
    [SerializeField] private bool isWorkig = false;
    public bool IsWorkig
    {
        set { isWorkig = value; }
        get { return isWorkig; }
    }
    [Header("Private Fields")]
    [SerializeField] private GameObject water;
    [SerializeField] private AIController assignedAI = null;

    public bool debugFlood = false;

    void Update()
    {
        if(isWorkig)
        {
            workingLvl += WorkSpeed * Time.deltaTime;
        }
        if (debugFlood)
            Flood();
    }

    public void AssignRoom(AIController assignee)
    {
        IsEmpty = false;
        assignedAI = assignee;
    }

    public void Flood()
    {
        if (water == null)
            return;
        water.SetActive(true);
        intresting = -1;
        if (assignedAI != null)
        {
            assignedAI.destiation = null;
            assignedAI = null;
        }

    }
}

enum roomType{ map,ring}
