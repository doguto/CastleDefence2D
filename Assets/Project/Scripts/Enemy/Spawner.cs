using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    //[SerializeField] GameObject[] enemiePrefabs; //Enemyˆê——HŠi”[•Ï”
    [SerializeField] SpawnInfoDB spawnInfoDB; //Spawnî•ñŠi”[ƒf[ƒ^ƒx[ƒX
    List<SpawnInfo> spawnInfoList;
    Enemy[] spawningEnemies; //Spawn‚·‚éEnemyŠi”[—p•Ï”

    [SerializeField] Transform[] landSpawnPoints; //SpawnPosition in LandŠi”[•Ï”
    [SerializeField] Transform[] skySpawnPoints; //SpawnPosition in SkyŠi”[”z—ñ
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
