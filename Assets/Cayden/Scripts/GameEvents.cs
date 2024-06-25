using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents gameEventManager;

    // Assignes the game event manager to this instance of the script
    private void Awake()
    {
        gameEventManager = this;
    }

    // New action is created which handles vehicle damage
    public event Action onVehicleDamaged;
    public void VehicleDamaged()
    {
        if (onVehicleDamaged != null)
        {
            onVehicleDamaged();
        }
    }
}
