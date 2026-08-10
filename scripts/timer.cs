using UnityEngine;
using TMPro; // Remove if using standard UI Text

public class timer : MonoBehaviour
{
    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI _timerText; // Drag your UI text here

    private float _elapsedTime;
    private bool _isRunning;

    void Start()
    {
        // Start timing automatically when scene loads (Optional)
        StartStopwatch();
    }

    void Update()
    {
        if (_isRunning)
        {
            _elapsedTime += Time.deltaTime;
            UpdateTimerUI();
        }
    }

    public void StartStopwatch()
    {
        _isRunning = true;
    }

    public void StopStopwatch()
    {
        _isRunning = false;
    }

    public void ResetStopwatch()
    {
        _elapsedTime = 0f;
        UpdateTimerUI();
    }

    private void UpdateTimerUI()
    {
        int minutes = Mathf.FloorToInt(_elapsedTime / 60);
        int seconds = Mathf.FloorToInt(_elapsedTime % 60);
        

        if (_timerText != null)
        {
            _timerText.text = string.Format("{0:00}{1:00}", minutes, seconds);
        }
    }
}