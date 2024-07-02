using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructiveObjects : MonoBehaviour
{
    public float objectSpeed;

    public Rigidbody rb;

    private void OnCollisionEnter(Collision obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            obj.gameObject.GetComponentInChildren<DamageCar>().ExternalDamageCalculator(objectSpeed);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        objectSpeed = rb.velocity.magnitude;
    }
}
