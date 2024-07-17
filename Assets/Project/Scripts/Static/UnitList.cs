using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitList : Singleton<UnitList>
{
    private static List<Enemy> enemies = new List<Enemy>();
    private static List<Soldier> soldiers = new List<Soldier>();
    [SerializeField] Gate _gate;
    private static Gate gate;
 
    public override void Awake()
    {
        RemoveDuplicates(); //Singleton

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

    public static bool ContainUnit<T>(T unit)
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
        Enemy targetEnemy = null;
        float minX = 100; //100:ÇΩÇæÇÃëÂÇ´Ç¢êî.ì¡Ç…à”ñ°ÇÕñ≥Ç¢.
        if (enemies == null)
        {
            return null;
        }

        foreach (Enemy enemy in enemies)
        {
            Vector2 enemyPosition = enemy.transform.position;
            if (!(centerPosition.x - width < enemyPosition.x && enemyPosition.x < centerPosition.x + width)) continue;

            if (minX == 100)
            {
                minX = enemyPosition.x;
                targetEnemy = enemy;
                continue;
            }

            if (enemyPosition.x > minX) continue;

            minX = enemyPosition.x;
            targetEnemy = enemy;
        }

        if (!targetEnemy) return null;

        return targetEnemy;
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

    public static Gate SetGate()
    {
        return gate;
    }
}
