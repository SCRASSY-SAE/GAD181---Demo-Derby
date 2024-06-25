using Deform;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCar : MonoBehaviour
{
    #region variables
    public float vehicleSpeed;
    [Range(0f, 100f)] public float vehicleHealth = 100f;
    public float vehicleDamage;
    #endregion

    #region references
    public Rigidbody rb;
    public PerlinNoiseDeformer perlinNoiseDeformer;
    #endregion

    #region functions
    void DamageCalculator()
    {
        if (vehicleSpeed > 40f)
        {
            vehicleHealth -= 40f;
            Debug.Log("40");
        }
        else if (vehicleSpeed > 30f)
        {
            vehicleHealth -= 30f;
            Debug.Log("30");
        }
        else if (vehicleSpeed > 20f)
        {
            vehicleHealth -= 20f;
            Debug.Log("20");
        }
        else if (vehicleSpeed > 15f)
        {
            vehicleHealth -= 10f;
            Debug.Log("15");
        }

        vehicleSpeed = 0;

        DeformMesh();
    }

    void DeformMesh()
    {
        if (vehicleHealth < 10f)
        {
            perlinNoiseDeformer.MagnitudeScalar = 0.6f;
        }
        else if (vehicleHealth < 20f)
        {
            perlinNoiseDeformer.MagnitudeScalar = 0.4f;
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
        rb = GetComponent<Rigidbody>();
        perlinNoiseDeformer = GetComponentInChildren<PerlinNoiseDeformer>();
    }
    #endregion

    #region collisions
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(vehicleSpeed);

        GameEvents.gameEventManager.VehicleDamaged();
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        GetRef();

        GameEvents.gameEventManager.onVehicleDamaged += DamageCalculator;
    }

    // Update is called once per frame
    void Update()
    {
        vehicleSpeed = rb.velocity.magnitude;
    }
}