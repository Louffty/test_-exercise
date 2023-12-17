using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngineInternal.XR.WSA;

public class PlayerController : MonoBehaviour
{
    public float speed;

    Vector3 velocity;

    void Start()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

       
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.W))
        { 
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(-Vector3.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
    }
}
