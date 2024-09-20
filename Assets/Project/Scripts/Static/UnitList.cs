using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitList : MonoBehaviour
{
    private static List<Enemy> _enemies = new List<Enemy>();
    private static List<Soldier> _soldiers = new List<Soldier>();
    [SerializeField] Gate _gateBase;
    private static Gate _gate;
 
    public void Awake()
    {
        //RemoveDuplicates(); //Singleton

        _enemies.Clear();
        _soldiers.Clear();

        _gate = _gateBase;
    }

    public static void AddUnit<T>(T unit)
    {
        if (unit is Enemy)
        {
            _enemies.Add(unit as Enemy);
        }
        else if (unit is Soldier)
        {
            _soldiers.Add(unit as Soldier);
        }
    }

    public static void RemoveUnit<T>(T unit)
    {
        if (unit is Enemy)
        {
            _enemies.Remove(unit as Enemy);
        }
        else if (unit is Soldier)
        {
            _soldiers.Remove(unit as Soldier);
        }
    }

    public static bool IsContainUnit<T>(T unit)
    {
        if (unit is Enemy)
        {
            return _enemies.Contains(unit as Enemy);
        }
        else if (unit is Soldier)
        {
            return _soldiers.Contains(unit as Soldier);
        }
        return false;
    }

    public static Enemy GetTargetEnemy(Vector2 centerPosition, float width)
    {
        int rank = 0;
        //float minX = 100; //100:ÇΩÇæÇÃëÂÇ´Ç¢êî.ì¡Ç…à”ñ°ÇÕñ≥Ç¢.
        if (_enemies.Count == 0)
        {
            return null;
        }

        Enemy[] targetCandidats = new Enemy[_enemies.Count];

        foreach (Enemy enemy in _enemies)
        {
            Vector2 enemyPosition = enemy.transform.position;
            if (!IsIn.Vector1Range(centerPosition.x - width/2, centerPosition.x + width/2, enemy.transform.position.x))
            {
                continue;
            }

            for (int i = 0; i < targetCandidats.Length; i++)
            {
                if (targetCandidats[i] == null)
                {
                    targetCandidats[i] = enemy;
                    break;
                }

                if (targetCandidats[i].transform.position.x < enemyPosition.x)
                {
                    continue;
                }

                for (int j = targetCandidats.Length - 1; j > i; j--)
                {
                    targetCandidats[j] = targetCandidats[j - 1];
                }
                targetCandidats[i] = enemy;
            }
        }

        if (targetCandidats.Length == 0)
        {
            return null;
        }

        int length = 0;
        for (int i = 0; i < targetCandidats.Length; i++)
        {
            if (targetCandidats[i] == null) break;
            
            length++;
            
            if (!targetCandidats[i].IsEngage) break;

            rank++;
        }

        if (length <= rank)
        {
            //return targetCandidats[targetCandidats.Length - 1];
            return targetCandidats[0];
        }
        
        return targetCandidats[rank];
    }

    public static AllyBase GetTargetAlly(Transform enemyTransform)
    {
        if (_soldiers == null) return _gate;

        AllyBase target = null;
        float tempDistance = 0;
        float finalDistance = 0;
        float minDistance = 0;

        foreach (Soldier robot in _soldiers)
        {
            tempDistance = (enemyTransform.position - robot.transform.position).sqrMagnitude;
            if (minDistance == 0)
            {
                minDistance = tempDistance;
                target = robot;
                continue;
            }

            if (tempDistance < minDistance)
            {
                minDistance = tempDistance;
                target = robot;
            }
        }
        finalDistance = (enemyTransform.position - _gate.transform.position).sqrMagnitude;

        if (finalDistance < minDistance)
            target = _gate;

        if (target == null)
            target = _gate;

        return target;
    }

    public static void HideSoldiers()
    {
        foreach (Soldier soldier in _soldiers)
        {
            if (!soldier) continue;

            soldier.gameObject.SetActive(false);
        }
    }

    public static Gate SetGate()
    {
        return _gate;
    }
}
