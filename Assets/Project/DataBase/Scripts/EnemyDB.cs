using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyDB : ScriptableObject
{
    public List<EnemyInfo> enemies = new List<EnemyInfo>();
}
