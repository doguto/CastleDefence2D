using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetEnemies : MonoBehaviour
{
    [SerializeField] List<Enemy> targetEnemies;

    private void Awake()
    {
        //targetEnemies = new List<Enemy>();
    }

    public void AddTarget(Enemy enemy)
    {
        if (!enemy) return;

        targetEnemies.Add(enemy);
    }

    public void DestroyTarget(Enemy enemy)
    {
        if (!enemy) return;
        if (!targetEnemies.Contains(enemy)) return;

        targetEnemies.Remove(enemy);
    }

    public bool ContainTarget(Enemy enemy)
    {
        if (!enemy) return false;

        if (targetEnemies.Contains(enemy)) return true;
        return false;
    }

    public Enemy GetTargetEnemy(Vector2 centerPosition, float width)
    {
        Enemy targetEnemy = null;
        float minX = 100; //100:‚½‚¾‚Ì‘å‚«‚¢”
        foreach (Enemy enemy in targetEnemies)
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
}

