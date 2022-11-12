using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public float cameraSpeed = 10;
    public float border = 10f;
    public Vector2 limit;
    public Vector2 limitScroll;
    public float cameraRotationSpeed;

    public float scroolSpeed = 20f;


    void Update()
    {
        Vector3 cameraPosition = transform.position;
        Quaternion cameraRotation = transform.rotation;

        if (Input.GetKey(KeyCode.W) || Input.mousePosition.y >= Screen.height - border)
        {
            cameraPosition.z += cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S) || Input.mousePosition.y <= border)
        {
            cameraPosition.z -= cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D) || Input.mousePosition.x >= Screen.width - border)
        {
            cameraPosition.x += cameraSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A) || Input.mousePosition.x <= border)
        {
            cameraPosition.x -= cameraSpeed * Time.deltaTime;
        }

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        cameraPosition.y -= scroll * scroolSpeed * 100f * Time.deltaTime;

        if (Input.GetMouseButton(2))
        {
            Cursor.lockState = CursorLockMode.Locked;
            //cameraRotation.y += Input.GetAxis("Mouse X") * Time.deltaTime;
        } else
            Cursor.lockState = CursorLockMode.Confined;

        cameraPosition.x = Mathf.Clamp(cameraPosition.x, -limit.x, limit.x);
        cameraPosition.y = Mathf.Clamp(cameraPosition.y, limitScroll.x, limitScroll.y);
        cameraPosition.z = Mathf.Clamp(cameraPosition.z, -limit.y, limit.y);

        transform.position = cameraPosition;
        transform.rotation = cameraRotation;


        
    }
}
