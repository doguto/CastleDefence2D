using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SpawnInfoDB : ScriptableObject
{
    public List<SpawnInfo> waveSpawnInfo = new List<SpawnInfo>();
}
