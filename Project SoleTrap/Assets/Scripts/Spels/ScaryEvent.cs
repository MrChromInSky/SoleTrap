using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaryEvent : MonoBehaviour
{

    private float timer = 1.5f;

    private void Update()
    {
        timer -= 1 * Time.deltaTime;
        if(timer <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.tag == "Human")
        {
            other.transform.GetComponent<AIController>().JumpScare(40);
        }
    }
}
