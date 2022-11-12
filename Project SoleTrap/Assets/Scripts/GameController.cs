using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public int howManyHumans = 0;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        if (howManyHumans == 0)
            Debug.Log("WIN!");
    }
}
