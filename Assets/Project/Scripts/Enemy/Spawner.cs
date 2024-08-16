using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] GameObject[] enemiePrefabs; //Enemyˆê——HŠi”[•Ï”
    [SerializeField] SpawnInfoDB _spawnInfoDB; //Spawnî•ñŠi”[ƒf[ƒ^ƒx[ƒX
    List<SpawnInfo> _spawnInfoList;
    [SerializeField] EnemyDB _enemyDB;
    List<EnemyInfo> _enemyList;
    //Enemy[] _spawningEnemies; //Spawn‚·‚éEnemyŠi”[—p•Ï”

    [SerializeField] Vector2[] _landSpawnPoints; //SpawnPosition in LandŠi”[•Ï”
    [SerializeField] Vector2[] _skySpawnPoints; //SpawnPosition in SkyŠi”[”z—ñ
    //readonly int enemyKindsInWave = 0;

    [SerializeField] float _spawnIntervalTime;
    WaitForSeconds _spawnDeray;

    private void Awake()
    {
        _spawnDeray = new WaitForSeconds(_spawnIntervalTime);
        _spawnInfoList = _spawnInfoDB.waveSpawnInfo;
        _enemyList = _enemyDB.enemies;
    }

    public void CallSpawn(int waveNumber)
    {
        StartCoroutine(SpawanCoroutin(waveNumber));
    }

    IEnumerator SpawanCoroutin(int waveNumber)
    {
        int waveAmount = _spawnInfoList[waveNumber].waveAmount;
        int spawnPosition = Random.Range(0, _landSpawnPoints.Length);

        for (int i = 0; i < waveAmount; i++)
        {
            Spawn(waveNumber, spawnPosition);
            yield return _spawnDeray;
        }

    }

    void Spawn(int waveNumber, int spawnPosition)
    {
        int waveEnemyUpper = _spawnInfoList[waveNumber].enemyUpper;
        int enemyIndex = Random.Range(0, waveEnemyUpper);
        Instantiate(_enemyList[enemyIndex].enemy, _landSpawnPoints[spawnPosition], Quaternion.identity);
    }
}
