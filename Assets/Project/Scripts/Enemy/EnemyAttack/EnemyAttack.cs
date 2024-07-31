using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : Attack
{
    [SerializeField] protected Enemy enemy;
    protected Transform enemyTransform;

    protected void Awake()
    {
        enemyTransform = transform;
    }

    protected abstract void Attack();

    protected abstract IEnumerator AttackWait();
}
