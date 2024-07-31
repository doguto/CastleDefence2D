using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToTitleButton : MonoBehaviour, IClicked
{
    readonly string _titleSceneName = "TitleScene";

    public void OnClicked()
    {
        SceneManager.LoadScene(_titleSceneName);
    }
}
