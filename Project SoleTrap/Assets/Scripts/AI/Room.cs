using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //public roomType;

    public float workingLvl = 0;
    public float intresting = 100;
    public bool isEmpty = true;
    public bool isWarkig = false;

    void Start()
    {
        
    }

    void Update()
    {
        if(isWarkig)
        {
            workingLvl += 0.5f * Time.deltaTime;
        }
    }
}

enum roomType{ map,ring}
