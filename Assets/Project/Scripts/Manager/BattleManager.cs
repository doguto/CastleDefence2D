using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] Spawner _spawner;
    [SerializeField] private SpawnInfoDB _spawnInfoDB;
    int _waveNumber = 1;
    float _nextSpawnTime = 0;

    [SerializeField] Timer _timer;
    [SerializeField] MoneyManager _moneyManager;

    [SerializeField] GameObject _congratulations;
    [SerializeField] GameObject _scoreIs;
    [SerializeField] FinalScore _finalScore;
    [SerializeField] GameObject _returnToTitleButton;
    readonly Vector2 _congratulationsEmergePoint = new Vector2(0, 0);
    readonly Vector2 _scoreEmergePosition = new Vector2(-2.5f, -1.5f);
    readonly Vector2 _returnButtonEmergePoint = new Vector2(2, -4.5f);

    bool _isCleared;

    private void Start()
    {
        _isCleared = false;
        StartBattle();
    }

    private void Update()
    {
        CheckSpawn();
    }

    void StartBattle()
    {
        _spawner.CallSpawn(_waveNumber);
        _nextSpawnTime = 10f;
        _timer.InitTimer();
        _moneyManager.StartMoney();
    }

    void CheckSpawn()
    {
        float currentTime = _timer.GetCurrentTime();
        if (currentTime < _nextSpawnTime) return;

        CallSpawn();
    }

    void CallSpawn()
    {
        _waveNumber++;
        if (_waveNumber > _spawnInfoDB.waveSpawnInfo.Count)
        {
            if (_isCleared) return;
            ClearGame();
            return;
        }

        _nextSpawnTime += _spawnInfoDB.waveSpawnInfo[_waveNumber - 1].waveSeconds;
        _spawner.CallSpawn(_waveNumber);
    }

    void ClearGame()
    {
        _isCleared = true;
        _timer.StopTimer();
        float finTime = _timer.GetCurrentTime();
        Instantiate(_congratulations, _congratulationsEmergePoint, Quaternion.identity);
        Instantiate(_scoreIs, _scoreEmergePosition, Quaternion.identity);
        _finalScore.DesplayFinalScore(finTime);
        Instantiate(_returnToTitleButton, _returnButtonEmergePoint, Quaternion.identity);

    }
}

