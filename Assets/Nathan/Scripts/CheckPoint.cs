using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class CheckPoint : MonoBehaviour
{
    public GameObject start;
    public GameObject finish;
    public GameObject[] Checkpoints;
   

    private float CheckpointNumber;
    private bool started;
    public bool finished;
    PlayerHUD timer;

    // Update is called once per frame
    void Start()
    {
        timer = FindFirstObjectByType<PlayerHUD>();
        CheckpointNumber = 0;
        started = false;
        finished = false;   
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.CompareTag("Checkpoint"))
       {
            GameObject thisCheckpoint = other.gameObject;

            if (thisCheckpoint == start && !started)
            {
                started = true;
                Debug.Log("Started");
            }
            else if (thisCheckpoint == finish && started)
            {
                if (CheckpointNumber == Checkpoints.Length)
                {
                    finished = true;
                    Debug.Log("finished");
                    TimerInfo.text = timer.timerText.text;
                    SceneManager.LoadScene("");
                }
                else
                {
                    Debug.Log("missed a checkpoint");
                }
            }
            for (int i = 0; i < Checkpoints.Length; i++)
            {
                if (finished)
                    return;
                if (thisCheckpoint ==  Checkpoints[i] && i == CheckpointNumber)
                {
                    Debug.Log("correct Checkpoint");
                    CheckpointNumber++;

                }
                else if (thisCheckpoint == Checkpoints[i] && i != CheckpointNumber)
                {
                    Debug.Log("incorrect Checkpoint");
                }
            }
       }

    }

}
