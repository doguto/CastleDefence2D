using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSoldierCollision : SoldierCollision
{
    protected override void Collision(Collider2D collision)
    {
        if (soldier.IsEngage) return;
        if (soldier.EngagingEnemy) return;
        if (collision.gameObject.tag != enemyTag) return;

        soldier.CanMove = false;
        soldier.IsEngage = true;
        soldier.EngagingEnemy = collision.gameObject.GetComponent<Enemy>();
        soldier.EngagingEnemyDamage = collision.gameObject.GetComponent<EnemyDamage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collision(collision);
    }
}
