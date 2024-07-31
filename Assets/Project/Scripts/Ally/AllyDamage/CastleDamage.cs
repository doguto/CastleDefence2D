using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDamage : AllyDamageBase
{
    public override void CallDamaged(int power)
    {
        if (power <= 0) return;

        Damaged(DamageAmount(power, ally.Durability));
    }

    protected override void Damaged(int damage)
    {
        if (damage == 0) return;
        if (ally.Hp <= 0)
        {
            ally.Hp = 0;
            allyDeath.CallDeath();
        }

        ally.Hp -= damage;
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
