using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public Transform healthBar;
    public Transform playerCar;
    [SerializeField] TextMeshPro timerText;

    float playerMaxHealth;
    public float timePassed;

    void UpdatePlayerHealthBar()
    {
        
        float playerHealth = playerCar.GetComponent<DamageCar>().vehicleHealth;

        healthBar.GetComponent<Slider>().value = playerHealth / playerMaxHealth;
    }
    void UpdateTimer()
    {

        timePassed += Time.deltaTime;
        int minutes = Mathf.FloorToInt(timePassed / 60);
        int seconds = Mathf.FloorToInt(timePassed % 60);
        int milliseconds = (int)(timePassed * 1000) % 1000;
        //timerText.text = timePassed.ToString();
        timerText.text = $"{minutes}:{seconds}.{milliseconds}";
    }

    // Start is called before the first frame update
    void Start()
    {
        playerMaxHealth = playerCar.GetComponent<DamageCar>().vehicleHealth;
        
        timePassed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerHealthBar();
        UpdateTimer();
    }
}
