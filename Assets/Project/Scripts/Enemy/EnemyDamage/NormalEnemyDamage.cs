using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyDamage : EnemyDamage
{
    private void Start()
    {
        enemy.CanDamaged = true;
    }

    public override void CallDamaged(int power)
    {
        if (power <= 0) return;
        if (!enemy.CanDamaged) return;

        Damaged(DamageAmount(power, enemy.Duration));
    }


    protected override void Damaged(int damage)
    {
        if (enemy.Hp - damage <= 0)
        {
            enemy.Hp = 0;
            enemyDeath.CallDeath();
            return;
        }
        enemy.Hp -= damage;
        StartCoroutine(DamagedEffect());
    }
}
