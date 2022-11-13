using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public enum RoomType { map, ring, normal, bones}

    private bool isDone = false;
    public GameObject lightForRingRoom;

    private GameController gamec;

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
    private void Start()
    {
        gamec = FindObjectOfType<GameController>();

        int random = Random.Range(0, 5);
        switch (random)
        {
            case 0:
                if (gamec.ringRoom == null)
                {
                    type = RoomType.ring;
                    intresting = 40;
                    lightForRingRoom.active = true;
                    gamec.ringRoom = transform.GetComponent<Room>();
                }
                else
                {
                    intresting = Random.Range(60, 100);
                    workingLvl = Random.Range(0, 40);

                    type = RoomType.map;
                }
                break;
            case 1:
                intresting = Random.Range(60, 100);
                workingLvl = Random.Range(0, 40);

                type = RoomType.map;
                break;
            case 2:
                intresting = Random.Range(60, 100);
                workingLvl = Random.Range(30, 80);

                type = RoomType.normal;
                break;
            case 3:
                intresting = Random.Range(60, 100);
                workingLvl = Random.Range(30, 80);

                type = RoomType.normal;
                break;
            case 4:
                intresting = Random.Range(60, 100);
                workingLvl = Random.Range(30, 80);

                type = RoomType.normal;
                break;
            case 5:
                intresting = Random.Range(60, 100);
                workingLvl = Random.Range(30, 80);

                type = RoomType.normal;
                break;
        }
    }

    void Update()
    {
        if(isWorkig)
        {
            workingLvl += WorkSpeed * Time.deltaTime;
        }
        if(isEmpty && assignedAI != null)
        {
            assignedAI = null;
        }
        if (workingLvl >= 100 && !isDone)
        {
            switch (Type)
            {
                case RoomType.map:
                    gamec.ringRoom.Intresting += 40;
                    break;
                case RoomType.ring:
                    Debug.Log("GAME OVER");
                    break;
                case RoomType.normal:
                    gamec.ringRoom.Intresting += 2;
                    break;
            }
            isDone = true;
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
