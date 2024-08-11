using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] GameObject[] enemiePrefabs; //Enemyˆê——HŠi”[•Ï”
    [SerializeField] SpawnInfoDB _spawnInfoDB; //Spawnî•ñŠi”[ƒf[ƒ^ƒx[ƒX
    List<SpawnInfo> _spawnInfoList;
    Enemy[] _spawningEnemies; //Spawn‚·‚éEnemyŠi”[—p•Ï”

    [SerializeField] Transform[] _landSpawnPoints; //SpawnPosition in LandŠi”[•Ï”
    [SerializeField] Transform[] _skySpawnPoints; //SpawnPosition in SkyŠi”[”z—ñ
    //readonly int enemyKindsInWave = 0;

    [SerializeField] float _spawnIntervalTime;
    WaitForSeconds _spawnDeray;

    private void Awake()
    {
        _spawnDeray = new WaitForSeconds(_spawnIntervalTime);
        _spawnInfoList = _spawnInfoDB.waveSpawnInfo;
    }

    public void CallSpawn(int waveNumber)
    {
        StartCoroutine(SpawanCoroutin(waveNumber));
    }

    IEnumerator SpawanCoroutin(int waveNumber)
    {
        int waveAmount = _spawnInfoList[waveNumber - 1].waveAmount;
        for (int i = 0; i < waveAmount; i++)
        {
            Spawn(waveNumber);
            yield return _spawnDeray;
        }

    }

    void Spawn(int waveNumber)
    {
        int waveEnemyKinds = _spawnInfoList[waveNumber - 1].enemies.Length;
        int enemyIndex = Random.Range(0, waveEnemyKinds - 1);
        int tempPoint = Random.Range(0,_landSpawnPoints.Length-1);
        Instantiate(_spawnInfoList[waveNumber - 1].enemies[enemyIndex], _landSpawnPoints[tempPoint].position, Quaternion.identity);
    }
}
