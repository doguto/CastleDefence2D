using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyCollision : EnemyCollision
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != robotTag && collision.gameObject.tag != gateTag) return;

        enemy.IsEngage = true;
        engagingAlly = collision.gameObject.GetComponent<Ally>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag != robotTag && collision.gameObject.tag != gateTag) return;

        enemy.IsEngage = false;
        engagingAlly = null;
    }
}
