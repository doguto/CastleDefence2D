using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyAttack : MonoBehaviour
{
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected Transform enemyTransform;
    [SerializeField] protected int power;
    [SerializeField] protected float attackInterval;
    protected WaitForSeconds attackDeray;

    protected abstract void Attack();

    protected abstract IEnumerator AttackWait();
}
