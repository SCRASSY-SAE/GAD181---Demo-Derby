using Deform;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCar : MonoBehaviour
{
    #region variables
    public float vehicleSpeed;
    public bool doesHaveBomb;
    [Range(0f, 100f)] public float vehicleHealth = 100f;
    #endregion

    #region references
    Rigidbody rb;
    PerlinNoiseDeformer perlinNoiseDeformer;
    ParticleSystem damageParticleSystem;
    #endregion

    #region functions
    // Handles damage for when the player takes fall damage or hits into another object
    void SelfDamageCalculator()
    {
        Debug.Log("Car Hit");

        if (vehicleSpeed > 25f)
        {
            vehicleHealth -= 40f;
            Debug.Log("40");
        }
        else if (vehicleSpeed > 20f)
        {
            vehicleHealth -= 30f;
            Debug.Log("30");
        }
        else if (vehicleSpeed > 15f)
        {
            vehicleHealth -= 20f;
            Debug.Log("20");
        }
        else if (vehicleSpeed > 10f)
        {
            vehicleHealth -= 10f;
            Debug.Log("15");
        }

        vehicleSpeed = 0;
        DeformMesh();
    }

    // Handles damage for objects which hit the players vehicle
    public void ExternalDamageCalculator(float speed)
    {
        if (speed > 40f)
        {
            vehicleHealth -= 40f;
            Debug.Log("40");
        }
        else if (speed > 30f)
        {
            vehicleHealth -= 30f;
            Debug.Log("30");
        }
        else if (speed > 20f)
        {
            vehicleHealth -= 20f;
            Debug.Log("20");
        }
        else if (speed > 15f)
        {
            vehicleHealth -= 10f;
            Debug.Log("15");
        }

        speed = 0;
        DeformMesh();
    }

    // Deforms the vehicle mesh when enough damage is dealt
    void DeformMesh()
    {
        if (vehicleHealth < 10f)
        {
            perlinNoiseDeformer.MagnitudeScalar = 0.6f;
        }
        else if (vehicleHealth < 20f)
        {
            perlinNoiseDeformer.MagnitudeScalar = 0.4f;
            SmokeParticleManager();
        }
        else if (vehicleHealth < 40)
        {
            perlinNoiseDeformer.MagnitudeScalar = 0.3f;
        }
        else if (vehicleHealth < 60)
        {
            perlinNoiseDeformer.MagnitudeScalar = 0.2f;
        }
        else if (vehicleHealth < 80)
        {
            perlinNoiseDeformer.MagnitudeScalar = 0.1f;
        }
    }

    void GetRef()
    {
        rb = transform.GetComponent<Rigidbody>();
        perlinNoiseDeformer = GetComponentInChildren<PerlinNoiseDeformer>();
        damageParticleSystem = GetComponentInChildren<ParticleSystem>();
    }

    void SmokeParticleManager()
    {
        damageParticleSystem.Play();
    }
    #endregion

    #region collisions
    private void OnCollisionEnter(Collision collision)
    {
        // Calls the vehicle damage game event
        SelfDamageCalculator();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        GetRef();
    }

    // Update is called once per frame
    void Update()
    {
        // Keeps track of the vehicles speed
        vehicleSpeed = rb.velocity.magnitude;
    }
}