using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public enum RoomType { map, ring }

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
        set
        {
            if (value < 0)
                value = 0;
            intresting = value; 
        }
        get
        {
            if (isBlocked)
                return -1;
            return intresting;
        }
    }
    [SerializeField] private bool isEmpty = true;
    public bool IsEmpty
    {
        set { isEmpty = value; }
        get { return isEmpty; }
    }
    [SerializeField] private bool isWorkig = false;
    public bool IsWorkig
    {
        set { isWorkig = value; }
        get { return isWorkig; }
    }
    [SerializeField] private RoomType type;
    public RoomType Type
    {
        set { type = value; }
        get { return type; }
    }
    [Header("Private Fields")]
    [SerializeField] private GameObject water;
    [SerializeField] private AIController assignedAI = null;
    [SerializeField] private bool isBlocked = false;

    void Update()
    {
        if(isWorkig)
        {
            workingLvl += WorkSpeed * Time.deltaTime;
        }
    }

    public void AssignRoom(AIController assignee)
    {
        IsEmpty = false;
        assignedAI = assignee;
    }

    public void UnassignRoom()
    {
        IsEmpty = true;
        assignedAI = null;
        isWorkig = false;
    }

    public void Flood()
    {
        if (water == null)
            return;
        water.SetActive(true);
        IsEmpty = false;
        isBlocked = true;
        if (assignedAI != null)
        {
            assignedAI.destiation = null;
            assignedAI = null;
        }
    }

    public void Drain()
    {
        water.SetActive(false);
        IsEmpty = true;
        isBlocked = false;
    }

}
