using Deform;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageCarScript : MonoBehaviour
{
    #region variables
    public float vehicleSpeed;
    public float vehicleHealth = 100f;
    public float vehicleDamage;
    #endregion

    #region references
    public Rigidbody rb;
    public Deformable vehicleDeformer;
    public PerlinNoiseDeformer perlinNoiseDeformer;
    #endregion

    #region functions
    void DamageCalculator()
    {
        if (vehicleSpeed > 40)
        {
            vehicleHealth -= 40;
            Debug.Log("40");
        }
        else if (vehicleSpeed > 30)
        {
            vehicleHealth -= 30;
            Debug.Log("30");
        }
        else if (vehicleSpeed > 20)
        {
            vehicleHealth -= 20;
            Debug.Log("20");
        }
        else if (vehicleSpeed > 15)
        {
            vehicleHealth -= 15;
            Debug.Log("15");
        }

        vehicleSpeed = 0;
    }

    void DeformMesh()
    {
        vehicleSpeed = rb.velocity.magnitude;

        if (vehicleHealth < 20f)
        {
            perlinNoiseDeformer.MagnitudeScalar = 0.5f;
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
        vehicleDeformer = GetComponentInChildren<Deformable>();
        perlinNoiseDeformer = GetComponentInChildren<PerlinNoiseDeformer>();
    }
    #endregion

    #region collisions
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(vehicleSpeed);

        DamageCalculator();
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
        DeformMesh();
    }
}
