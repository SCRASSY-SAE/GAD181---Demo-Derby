using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    public Transform healthBar;
    public Transform playerCar;

    float playerMaxHealth;

    void UpdatePlayerHealthBar()
    {
        
        float playerHealth = playerCar.GetComponent<DamageCar>().vehicleHealth;

        healthBar.GetComponent<Slider>().value = playerHealth / playerMaxHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMaxHealth = playerCar.GetComponent<DamageCar>().vehicleHealth;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerHealthBar();
    }
}
