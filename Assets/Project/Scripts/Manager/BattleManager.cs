using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] Spawner spawner;
    [SerializeField] private SpawnInfoDB spawnInfoDB;
    int waveNumber = 1;
    float nextSpawnTime = 0;

    [SerializeField] Timer _Timer;
    [SerializeField] MoneyManager _MoneyManager;

    [SerializeField] GameObject congratulations;
    [SerializeField] GameObject scoreIs;
    [SerializeField] FinalScore _FinalScore;
    [SerializeField] GameObject returnToTitleButton;
    readonly Vector2 congratulationsEmergePoint = new Vector2(0, 0);
    readonly Vector2 scoreEmergePosition = new Vector2(-2.5f, -1.5f);
    readonly Vector2 returnButtonEmergePoint = new Vector2(2, -4.5f);

    bool isCleared;

    private void Start()
    {
        isCleared = false;
        StartBattle();
    }

    private void Update()
    {
        CheckSpawn();
    }

    void StartBattle()
    {
        spawner.CallSpawn(waveNumber);
        nextSpawnTime = 10f;
        _Timer.InitTimer();
        _MoneyManager.StartMoney();
    }

    void CheckSpawn()
    {
        float currentTime = _Timer.GetCurrentTime();
        if (currentTime < nextSpawnTime) return;

        CallSpawn();
    }

    void CallSpawn()
    {
        waveNumber++;
        if (waveNumber > spawnInfoDB.waveSpawnInfo.Count)
        {
            if (isCleared) return;
            ClearGame();
            return;
        }

        nextSpawnTime += spawnInfoDB.waveSpawnInfo[waveNumber - 1].waveSeconds;
        spawner.CallSpawn(waveNumber);
    }

    void ClearGame()
    {
        isCleared = true;
        _Timer.StopTimer();
        float finTime = _Timer.GetCurrentTime();
        Instantiate(congratulations, congratulationsEmergePoint, Quaternion.identity);
        Instantiate(scoreIs, scoreEmergePosition, Quaternion.identity);
        _FinalScore.DesplayFinalScore(finTime);
        Instantiate(returnToTitleButton, returnButtonEmergePoint, Quaternion.identity);

    }
}

