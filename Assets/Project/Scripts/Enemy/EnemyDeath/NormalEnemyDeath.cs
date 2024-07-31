using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyDeath : EnemyDeath
{
    public override void CallDeath()
    {
        Death();
    }

    protected override void Death()
    {
        enemy.EngagingAlly.EngagingAmount--;
        Instantiate(enemySoul, myTransform.position, Quaternion.identity);
        UnitList.RemoveUnit<Enemy>(this.gameObject.GetComponent<Enemy>());
        Destroy(this.gameObject);
    }
}
