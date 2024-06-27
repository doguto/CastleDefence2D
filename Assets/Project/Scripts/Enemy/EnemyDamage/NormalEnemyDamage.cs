using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyDamage : EnemyDamage
{
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
            //Death();
        }
        enemy.Hp -= damage;
        StartCoroutine(DamagedEffect());
    }


    protected override int DamageAmount(int power, int duration)
    {
        if (power - duration < 0)
        {
            return 0;
        }
        return power - duration;
    }
}
