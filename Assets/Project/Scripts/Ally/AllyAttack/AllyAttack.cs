using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyAttack : Attack
{
    protected abstract void Attack();

    protected abstract IEnumerator AttackWait();
}
