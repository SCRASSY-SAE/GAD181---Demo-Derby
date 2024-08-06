using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{
    public TextMeshPro timerText;
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
    public void 

}
