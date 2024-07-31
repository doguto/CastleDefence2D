using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSoldierCollision : SoldierCollision
{
    [SerializeField] AllyDamageBase allyDamage;

    protected override void Collision(Collider2D collision)
    {
        if (soldier.IsEngage) return;
        if (soldier.IsFullEngage) return;
        if (collision.gameObject.tag != enemyTag) return;

        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy != soldier.TargetEnemy) return;

        
        SetEngage(enemy);
    }

    public override void SetEngage(Enemy enemy)
    {
        if (!soldier.TargetEnemy) return;

        soldier.IsEngage = true;
        soldier.EngagingAmount++;
        soldier.EngagingEnemy = enemy;

        if (!soldier.EngagingEnemy) return;

        enemy.IsEngage = true;
        enemy.EngagingAlly = soldier;
        enemy.EngagingAllyDamage = allyDamage;

        if (!enemy) return;

        soldier.EngagingEnemyDamage = enemy.gameObject.GetComponent<EnemyDamage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collision(collision);
    }
}
