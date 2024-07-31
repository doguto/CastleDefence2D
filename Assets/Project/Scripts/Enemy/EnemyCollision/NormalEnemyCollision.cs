using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyCollision : EnemyCollisionBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemy.IsEngage) return;
        if (enemy.EngagingAlly) return;

        string collisionTag = collision.gameObject.tag;
        if (collisionTag != soldierTag && collisionTag != gateTag) return;

        enemy.IsEngage = true;
        enemy.EngagingAlly = collision.gameObject.GetComponent<AllyBase>();
        enemy.EngagingAllyDamage = collision.gameObject.GetComponent<AllyDamageBase>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        string collisionTag = collision.gameObject.tag;
        if (collisionTag != soldierTag && collisionTag != gateTag) return;
        if (enemy.EngagingAlly) return;
        if (collisionTag != enemy.EngagingAlly.gameObject.tag) return;

        enemy.IsEngage = false;
        enemy.EngagingAlly = null;
        enemy.EngagingAllyDamage = null;
    }
}
