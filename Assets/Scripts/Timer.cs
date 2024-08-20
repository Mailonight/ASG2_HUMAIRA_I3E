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

/// <summary>
/// Manages a countdown timer displayed on the UI.
/// </summary>
public class Timer : MonoBehaviour
{
    /// <summary>
    /// Reference to the TextMeshProUGUI component used to display the timer.
    /// </summary>
    public TextMeshProUGUI timerText;

    /// <summary>
    /// Total time for the countdown in seconds.
    /// </summary>
    public float totalTime = 60f;

    /// <summary>
    /// Initializes the timer by starting the countdown coroutine.
    /// </summary>
    private void Start()
    {
        StartCoroutine(StartTimer());
    }

    /// <summary>
    /// Coroutine that handles the countdown and updates the timer text.
    /// </summary>
    /// <returns>An IEnumerator to control the coroutine's execution.</returns>
    private IEnumerator StartTimer()
    {
        float timeRemaining = totalTime;

        while (timeRemaining > 0f)
        {
            // Update the timer display
            timerText.text = FormatTime(timeRemaining);

            // Decrease the time remaining
            timeRemaining -= Time.deltaTime;

            yield return null;
        }

        // Time's up, perform game over or other actions here
        Debug.Log("Time's up!");
    }

    /// <summary>
    /// Formats the given time in seconds into a MM:SS string format.
    /// </summary>
    /// <param name="timeInSeconds">Time in seconds to format.</param>
    /// <returns>A formatted string representing the time in MM:SS format.</returns>
    private string FormatTime(float timeInSeconds)
    {
        int minutes = Mathf.FloorToInt(timeInSeconds / 60f);
        int seconds = Mathf.FloorToInt(timeInSeconds % 60f);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}