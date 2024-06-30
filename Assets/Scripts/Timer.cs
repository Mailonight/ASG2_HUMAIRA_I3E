/*
 * Author: Nur Humaira Binte Ahmad Nazim
 * Date: 10/05/2024
 * Description: 
 * Functions of timer.
 */

using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;


public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText; //Correct data type of text. 
    public float totalTime = 60f; // Total time in seconds

    private void Start()
    {
        StartCoroutine(StartTimer());
    }

    private IEnumerator StartTimer()
    {
        float timeRemaining = totalTime;

        while (timeRemaining > 0f)
        {
            // Update timer text
            timerText.text = FormatTime(timeRemaining);

            // Decrease time remaining
            timeRemaining -= Time.deltaTime;

            yield return null;
        }

        // Time's up, perform game over or other actions here
        Debug.Log("Time's up!");
    }

    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}