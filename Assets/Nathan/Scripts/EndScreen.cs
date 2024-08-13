using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        timerText.text = TimerInfo.text;    
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("TestingScene");
    }

}
