using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] GameObject[] enemiePrefabs; //Enemy�ꗗ�H�i�[�ϐ�
    [SerializeField] SpawnInfoDB spawnInfoDB; //Spawn���i�[�f�[�^�x�[�X
    List<SpawnInfo> spawnInfoList;
    Enemy[] spawningEnemies; //Spawn����Enemy�i�[�p�ϐ�

    [SerializeField] Transform[] landSpawnPoints; //SpawnPosition in Land�i�[�ϐ�
    [SerializeField] Transform[] skySpawnPoints; //SpawnPosition in Sky�i�[�z��
    //readonly int enemyKindsInWave = 0;

    [SerializeField] float spawnIntervalTime;
    WaitForSeconds spawnDeray;

    private void Awake()
    {
        spawnDeray = new WaitForSeconds(spawnIntervalTime);
        spawnInfoList = spawnInfoDB.waveSpawnInfo;
    }

    public void CallSpawn(int waveNumber)
    {
        StartCoroutine(SpawanCoroutin(waveNumber));
    }

    IEnumerator SpawanCoroutin(int waveNumber)
    {
        int waveAmount = spawnInfoList[waveNumber - 1].waveAmount;
        for (int i = 0; i < waveAmount; i++)
        {
            Spawn(waveNumber);
            yield return spawnDeray;
        }

    }

    void Spawn(int waveNumber)
    {
        int waveEnemyKinds = spawnInfoList[waveNumber - 1].enemies.Length;
        int enemyIndex = Random.Range(0, waveEnemyKinds - 1);
        int tempPoint = Random.Range(0,landSpawnPoints.Length-1);
        Instantiate(spawnInfoList[waveNumber - 1].enemies[enemyIndex], landSpawnPoints[tempPoint].position, Quaternion.identity);
    }
}
