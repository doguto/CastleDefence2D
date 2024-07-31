using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButtom : MonoBehaviour, IClicked
{
    readonly string battleScene = "BattleScene";

    public void OnClicked()
    {
        GameStart();
    }

    void GameStart()
    {
        SceneManager.LoadScene(battleScene);
    }
}
