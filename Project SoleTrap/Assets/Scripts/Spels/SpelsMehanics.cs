using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpelsMehanics : MonoBehaviour
{
    public float manna = 0f;

    public float magicNumber = 1;

    public GameObject[] objects;
    public float[] colldwon;

    void Start()
    {
        
    }

    void Update()
    {
        manna += magicNumber * Time.deltaTime;
        for (int i = 0; i < colldwon.Length; i++)
        {
            colldwon[i] += 1 * Time.deltaTime;
        }
    }

    public void GhostEvent()
    {
        if(colldwon[0] >= 30 && manna >= 20)
        {
            manna -= 20;
            GameObject ghost = Instantiate(objects[0], transform) as GameObject;
            colldwon[0] = 0;
        }
    }
}
