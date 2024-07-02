using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public float turn;
    Rigidbody rb;

    public Transform frontWheel01;
    public Transform frontWheel02;
    public Transform backWheel01;
    public Transform backWheel02;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float z = 0;
        float x = 0;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x -= 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x += 1;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            z += 1;

            frontWheel01.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
            frontWheel02.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));
            backWheel01.Rotate(new Vector3(0, 0, speed * Time.deltaTime));
            backWheel02.Rotate(new Vector3(0, 0, -speed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            z -= 1;
        }
                
        rb.AddForce(transform.right * z * -2000);
        //rb.AddForce(transform.up * 1000);
        //rb.AddRelativeTorque(new Vector3(0, x*turn, 0));

        float vehicleVelocity = rb.velocity.magnitude * 10;
        
        
    }
}