using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyCollision : EnemyCollision
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != robotTag && collision.gameObject.tag != gateTag) return;

        enemy.IsEngage = true;
        enemy.engagingAlly = collision.gameObject.GetComponent<Ally>();
        enemy.engagingAllyCollision = collision.gameObject.GetComponent<AllyHpManager>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != robotTag && collision.gameObject.tag != gateTag) return;

        enemy.IsEngage = false;
        enemy.engagingAlly = null;
        enemy.engagingAllyCollision = null;
    }
}
