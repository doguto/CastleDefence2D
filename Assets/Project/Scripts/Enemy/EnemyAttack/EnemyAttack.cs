using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : Attack
{
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected Transform enemyTransform;

    protected abstract void Attack();

    protected abstract IEnumerator AttackWait();
}
