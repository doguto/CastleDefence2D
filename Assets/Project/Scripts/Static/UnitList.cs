using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class UnitList : MonoBehaviour
{
    private static List<Enemy> enemies = new List<Enemy>();
    private static List<Soldier> soldiers = new List<Soldier>();
    [SerializeField] Gate _gate;
    private static Gate gate;
 
    public void Awake()
    {
        //RemoveDuplicates(); //Singleton

        enemies.Clear();
        soldiers.Clear();

        gate = _gate;
    }

    public static void AddUnit<T>(T unit)
    {
        if (unit is Enemy)
        {
            enemies.Add(unit as Enemy);
        }
        else if (unit is Soldier)
        {
            soldiers.Add(unit as Soldier);
        }
    }

    public static void RemoveUnit<T>(T unit)
    {
        if (unit is Enemy)
        {
            enemies.Remove(unit as Enemy);
        }
        else if (unit is Soldier)
        {
            soldiers.Remove(unit as Soldier);
        }
    }

    public static bool IsContainUnit<T>(T unit)
    {
        if (unit is Enemy)
        {
            return enemies.Contains(unit as Enemy);
        }
        else if (unit is Soldier)
        {
            return soldiers.Contains(unit as Soldier);
        }
        return false;
    }

    public static Enemy GetTargetEnemy(Vector2 centerPosition, float width)
    {
        int rank = 0;
        //float minX = 100; //100:ÇΩÇæÇÃëÂÇ´Ç¢êî.ì¡Ç…à”ñ°ÇÕñ≥Ç¢.
        if (enemies.Count == 0)
        {
            return null;
        }

        Enemy[] targetCandidats = new Enemy[enemies.Count];

        foreach (Enemy enemy in enemies)
        {
            Vector2 enemyPosition = enemy.transform.position;
            if (!IsIn.Vector1Range(centerPosition.x - width, centerPosition.x + width, enemy.transform.position.x))
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

        for (int i = 0; i < targetCandidats.Length; i++)
        {
            if (targetCandidats[i] == null) break;
            if (!targetCandidats[i].IsEngage) break;

            rank++;
        }

        if (targetCandidats.Length - 1 < rank)
        {
            return targetCandidats[targetCandidats.Length - 1];
        }
        
        return targetCandidats[rank];
    }

    public static AllyBase GetTargetAlly(Transform enemyTransform)
    {
        if (soldiers == null) return gate;

        AllyBase target = null;
        float tempDistance = 0;
        float finalDistance = 0;
        float minDistance = 0;

        foreach (Soldier robot in soldiers)
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
        finalDistance = (enemyTransform.position - gate.transform.position).sqrMagnitude;

        if (finalDistance < minDistance)
            target = gate;

        if (target == null)
            target = gate;

        return target;
    }

    public static void HideSoldiers()
    {
        foreach (Soldier soldier in soldiers)
        {
            if (!soldier) continue;

            soldier.gameObject.SetActive(false);
        }
    }

    public static Gate SetGate()
    {
        return gate;
    }
}
