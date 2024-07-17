using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour
{
    [SerializeField] Spawner spawner;
    [SerializeField] private SpawnInfoDB spawnInfoDB;
    int waveNumber = 1;
    BattleTimer battleTimer = new BattleTimer();

    private void Start()
    {
        battleTimer.Reset();
        startBattle();
    }

    private void Update()
    {
        CheckSpawn();
    }

    void startBattle()
    {
        spawner.CallSpawn(waveNumber);
    } 

    void CheckSpawn()
    {

    }
}


class BattleTimer
{
     float _seconds;
    public float seconds
    {
        get { return Time.time - _seconds; }
    }

    //bool canClock = true;

    public void Reset()
    {
        _seconds = Time.time;
    }
}
