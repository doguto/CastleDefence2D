using UnityEngine;
using UnityEngine.UI; // UI�R���|�[�l���g���g�p����ꍇ
using TMPro;

public class Timer : MonoBehaviour
{
    float _timeRemaining = 0f; // �^�C�}�[�̏�������
    bool _timerIsRunning = false;
    [SerializeField]TextMeshProUGUI _timeText; // �^�C�}�[�\���p��Text UI

    private void Start()
    {
        // �Q�[���J�n���Ƀ^�C�}�[���J�n
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

