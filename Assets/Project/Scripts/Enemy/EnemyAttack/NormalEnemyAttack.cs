using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalEnemyAttack : EnemyAttack
{
    [SerializeField] float attackTime;
    WaitForSeconds attackingDeray;
    [SerializeField] float attackAngle;
    Vector3 attackRotation;

    private void Awake()
    {
        attackRotation = new Vector3(0, 0, attackAngle);
        attackDeray = new WaitForSeconds(attackInterval);
        attackingDeray = new WaitForSeconds(attackTime);
    }

    private void Update()
    {
        Attack();
    }

    protected override void Attack()
    {
        if (!enemy.CanAttack) return;
        if (!enemy.IsEngage) return;
        if (!enemy.EngagingAlly)
        {
            enemy.IsEngage = false;
            enemy.CanMove = true;
            return;
        }

        enemy.CanAttack = false;
        StartCoroutine(AttackingCoroutin());
    }

    IEnumerator AttackingCoroutin()
    {
        Vector3 preRotation = enemyTransform.eulerAngles;
        Vector3 postRotation = preRotation + attackRotation;
        enemyTransform.eulerAngles = postRotation;
        enemy.EngagingAllyDamage.CallDamaged(power);
        yield return attackingDeray;
        enemyTransform.eulerAngles = preRotation;
        StartCoroutine(AttackWait());
    }

    protected override IEnumerator AttackWait()
    {
        yield return attackDeray;
        enemy.CanAttack = true;
    }
}
