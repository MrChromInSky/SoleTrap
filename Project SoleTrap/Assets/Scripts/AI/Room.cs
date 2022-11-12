using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //public roomType;

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
        set { isEmpty = value; }
        get { return isEmpty; }
    }
    [SerializeField] private bool isWorkig = false;
    public bool IsWorkig
    {
        set { isWorkig = value; }
        get { return isWorkig; }
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(isWorkig)
        {
            workingLvl += 0.5f * Time.deltaTime;
        }
    }
}

enum roomType{ map,ring}
