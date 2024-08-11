using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] GameObject[] enemiePrefabs; //Enemy�ꗗ�H�i�[�ϐ�
    [SerializeField] SpawnInfoDB _spawnInfoDB; //Spawn���i�[�f�[�^�x�[�X
    List<SpawnInfo> _spawnInfoList;
    Enemy[] _spawningEnemies; //Spawn����Enemy�i�[�p�ϐ�

    [SerializeField] Transform[] _landSpawnPoints; //SpawnPosition in Land�i�[�ϐ�
    [SerializeField] Transform[] _skySpawnPoints; //SpawnPosition in Sky�i�[�z��
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
