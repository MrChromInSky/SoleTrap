using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{

    public Transform cameraHolder;

    void Update()
    {
        Vector3 positionGO = new Vector3(cameraHolder.position.x, 1.8f, cameraHolder.position.z);
        transform.position = positionGO;
    }
}
