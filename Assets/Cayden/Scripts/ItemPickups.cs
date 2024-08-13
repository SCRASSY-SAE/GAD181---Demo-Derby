using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemPickups : MonoBehaviour
{
    #region variables
    public Transform a;
    public Transform b;
    public float time;
    public int direction = 1;

    public float healthBoostValue;
    public float speedBoostValue;
    public float bombDamageValue;
    public enum itemType { HealthBoost, SpeedBoost}
    public itemType itemClassType;
    #endregion

    #region functions
    Vector3 CurrentMovementTarget()
    {
        if (direction == 1)
        {
            return a.position;
        }
        else
        {
            return b.position;
        }
    }

    void ItemBob()
    {
        Vector3 target = CurrentMovementTarget();

        transform.position = Vector3.Lerp(transform.position, target, time * Time.deltaTime);

        float distance = (target - (Vector3)transform.position).magnitude;

        if (distance <= 0.1f)
        {
            direction *= -1;
        }
    }
    #endregion

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ItemBob();
    }

    private void OnTriggerEnter(Collider collidedObj)
    {
        Debug.Log(collidedObj.gameObject.tag);

        if (collidedObj.gameObject.tag == "Player" && collidedObj.gameObject.GetComponentInParent<DamageCar>())
        {
            DamageCar damageCar = collidedObj.gameObject.GetComponentInParent<DamageCar>();

            switch (itemClassType)
            {
                // Health boost item system
                case itemType.HealthBoost:
                    Debug.Log("Health");

                    float playerHealth = damageCar.vehicleHealth;
                    playerHealth += healthBoostValue;

                    Destroy(this);
                    break;

                // Speed boost item system
                case itemType.SpeedBoost:
                    Debug.Log("Speed");

                    Destroy(this);
                    break;
            }
        }
    }
}