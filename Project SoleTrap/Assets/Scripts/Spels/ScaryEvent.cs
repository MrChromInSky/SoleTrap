using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine;

public class ScaryEvent : MonoBehaviour
{
    private float timer = 1.5f;

    [SerializeField] private int sanityDamage;
    public int SanityDamage
    {
        set { sanityDamage = value; }
        get { return sanityDamage; }
    }

    private void Update()
    {
        timer -= 1 * Time.deltaTime;
        if(timer <= 0)
            Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Human")
        {
            other.transform.GetComponent<AIController>().JumpScare(sanityDamage);
        }
    }
}
