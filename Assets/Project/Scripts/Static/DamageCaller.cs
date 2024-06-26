using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DamageCaller
{
    public static void CallDamaged(IDamagable damagable, int damage)
    {
        damagable.Damaged(damage);
    }
}
