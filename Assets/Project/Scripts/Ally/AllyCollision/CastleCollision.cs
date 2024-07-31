using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleCollision : CastleCollisionBase
{
    protected override void Collision(Collider2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (!enemy) return;

        enemy.IsEngage = true;
        enemy.EngagingAlly = gate;
        enemy.EngagingAllyDamage = damage;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != enemyTag) return;

        Collision(collision);
    }
}
