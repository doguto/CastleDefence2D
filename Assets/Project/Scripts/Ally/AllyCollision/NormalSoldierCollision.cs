using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSoldierCollision : SoldierCollision
{
    [SerializeField] AllyDamage allyDamage;

    protected override void Collision(Collider2D collision)
    {
        if (soldier.IsEngage) return;
        if (soldier.IsFullEngage) return;
        if (collision.gameObject.tag != enemyTag) return;

        Debug.Log("collision");
        soldier.CanMove = false;
        soldier.IsEngage = true;
        soldier.EngagingAmount++;
        soldier.EngagingEnemy = collision.gameObject.GetComponent<Enemy>();
        soldier.EngagingEnemy.IsEngage = true;
        soldier.EngagingEnemy.EngagingAlly = soldier;
        soldier.EngagingEnemy.EngagingAllyDamage = allyDamage;
        soldier.EngagingEnemyDamage = collision.gameObject.GetComponent<EnemyDamage>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collision(collision);
    }
}
