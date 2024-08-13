using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class  TimerInfo
{
    public static string text;
}


public class PlayerHUD : MonoBehaviour
{

    public Transform playerCar;
    public TextMeshPro timerText;
    CheckPoint Finish;

    public float timePassed;
    public bool CanMove = false;

    
    void UpdateTimer()
    {

        
            timePassed += Time.deltaTime;
            int minutes = Mathf.FloorToInt(timePassed / 60);
            int seconds = Mathf.FloorToInt(timePassed % 60);
            int milliseconds = (int)(timePassed * 1000) % 1000;
            timerText.text = timePassed.ToString();
            timerText.text = $"{minutes}:{seconds}.{milliseconds}";
            if (timePassed >= 0 && CanMove == false)
            {
                CanMove = true;
                Debug.Log("Timer");
            }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(timerText.gameObject);
        TimerInfo.text = timerText.text;
        timePassed = -3f;
    }

    // Update is called once per frame
    void Update()
    {
       
        UpdateTimer();
       
    }
}
