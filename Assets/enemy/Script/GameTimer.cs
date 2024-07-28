using System.Collections;
using UnityEngine;
using UnityEngine.UI; // Import the UI namespace

public class GameTimer : MonoBehaviour
{
    private float gameDuration = 300f; // Making time duration of 5 minutes
    private float timer = 0f;
    private logicManager logicManager;

    [SerializeField] private Text timerText; // Reference to the UI Text element

    private void Start()
    {
        // Find the logicManager in the scene
        logicManager = FindObjectOfType<logicManager>();

        // Check if the timerText is assigned
        if (timerText == null)
        {
            Debug.LogError("Timer Text not assigned in the inspector!");
            return;
        }

        // Start the game timer
        StartCoroutine(GameTimerCoroutine());
    }

    private IEnumerator GameTimerCoroutine()
    {
        // Countdown timer loop
        while (timer < gameDuration)
        {
            timer += Time.deltaTime;

            // Update the timer UI
            UpdateTimerUI();

            yield return null;
        }

        // When the time is up, call the GameOver method from logicManager
        logicManager.gameOver();
    }

    private void UpdateTimerUI()
    {
        float remainingTime = gameDuration - timer;
        timerText.text = remainingTime.ToString("F1");
    }
}
