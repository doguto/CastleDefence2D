using UnityEngine;
using UnityEngine.UI; // UIコンポーネントを使用する場合
using TMPro;

public class Timer : MonoBehaviour
{
    float _timeRemaining = 0f; // タイマーの初期時間
    bool _timerIsRunning = false;
    [SerializeField]TextMeshProUGUI _timeText; // タイマー表示用のText UI

    private void Start()
    {
        // ゲーム開始時にタイマーを開始
        //_timerIsRunning = true;
    }

    void Update()
    {
        ClockTimer();
    }

    public void InitTimer()
    {
        if (_timerIsRunning) return;

        _timeRemaining = 0f;
        _timerIsRunning = true;
    }

    public void StopTimer()
    {
        if (!_timerIsRunning) return;

        _timerIsRunning = false;
    }

    public float GetCurrentTime()
    {
        return _timeRemaining;
    }

    void ClockTimer()
    {
        if (!_timerIsRunning) return;

        _timeRemaining += Time.deltaTime;
        DisplayTime(_timeRemaining);
    }

    void DisplayTime(float timeToDisplay)
    {
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        _timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}

