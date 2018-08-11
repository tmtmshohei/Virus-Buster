using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    public float speed = 100.0f;
    public Rigidbody rb;

    void Start()
    {
         rb= GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {

 
            float x = Input.GetAxis("Horizontal") * speed;
            float z = Input.GetAxis("Vertical") * speed;
            rb.AddForce(x, 0, z);



    }


}

    




