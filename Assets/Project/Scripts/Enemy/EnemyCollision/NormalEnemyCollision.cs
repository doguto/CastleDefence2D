using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyCollision : EnemyCollision
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemy.IsEngage) return;
        if (enemy.EngagingAlly) return;

        string collisionTag = collision.gameObject.tag;
        if (collisionTag != soldierTag && tag != gateTag) return;

        enemy.IsEngage = true;
        enemy.EngagingAlly = collision.gameObject.GetComponent<Ally>();
        enemy.EngagingAllyDamage = collision.gameObject.GetComponent<AllyDamage>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string collisionTag = collision.gameObject.tag;
        if (collisionTag != soldierTag && tag != gateTag) return;

        enemy.IsEngage = false;
        enemy.EngagingAlly = null;
        enemy.EngagingAllyDamage = null;
    }
}
