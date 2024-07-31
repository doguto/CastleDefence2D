using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalScore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _finalScoreText;

    private void Start()
    {
        _finalScoreText.text = string.Empty;
    }

    public void DesplayFinalScore(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        _finalScoreText.text = string.Format("Survive Time is => {0:00}:{1:00}", minutes, seconds);
    }
}
