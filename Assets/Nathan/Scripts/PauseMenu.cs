using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public bool isPaused;
    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void Pause()
    {
        if (isPaused == false && Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = true;
            Time.timeScale = 0;
        }
        if (isPaused && Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = false;
            Time.timeScale = 1;
        }
    }
    public void Back()
    {
        isPaused = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Title Screen");  
    }
    public void Quit()
    {
        Debug.Log("hello");
        Application.Quit();
    }
    public void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
    }
}
