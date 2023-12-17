using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseLook : MonoBehaviour
{
    public float mouseSensitiviti = 100f;
    public Transform playerBody;
    float xRotation = 0f;


    public static bool canMoving = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

 
    void Update()
    {
        if (canMoving)
        {
            if (Cursor.lockState == CursorLockMode.Confined)
            {
                Cursor.lockState = CursorLockMode.Locked;
            }

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitiviti * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitiviti * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
        else
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
