using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryEvent : MonoBehaviour
{

    public bool isWarking = false;

    void Start()
    {
        
    }

    void Update()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag == "Human" && isWarking)
        {
            other.transform.GetComponent<AIController>().JumpScare(40);
            isWarking = false;
            Destroy(gameObject);
        }
    }
}
