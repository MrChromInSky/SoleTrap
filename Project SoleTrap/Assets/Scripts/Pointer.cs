using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;

    void Update()
    {
        transform.position = new Vector3(cameraTransform.position.x, 2.2f, cameraTransform.position.z);
    }
}
