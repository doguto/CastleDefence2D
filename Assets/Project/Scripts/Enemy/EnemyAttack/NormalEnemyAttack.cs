using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class NormalEnemyAttack : EnemyAttack
{
    [SerializeField] float _attackTime;
    WaitForSeconds _attackingDeray;
    [SerializeField] float _attackAngle;
    Vector3 _attackRotation;

    private void Start()
    {
        _attackRotation = new Vector3(0, 0, _attackAngle);
        attackDeray = new WaitForSeconds(attackInterval);
        _attackingDeray = new WaitForSeconds(_attackTime);
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

        if (!this.gameObject.activeSelf) return;

        StartCoroutine(AttackingCoroutin());
    }

    IEnumerator AttackingCoroutin()
    {
        if (this.gameObject.activeSelf)
        {
            Vector3 preRotation = enemyTransform.localEulerAngles;
            Vector3 postRotation = preRotation + _attackRotation;
            enemyTransform.localEulerAngles = postRotation;
            enemy.EngagingAllyDamage.CallDamaged(power);

            yield return _attackingDeray;

            enemyTransform.localEulerAngles = preRotation;
            StartCoroutine(AttackWait());
        }
    }

    protected override IEnumerator AttackWait()
    {
        yield return attackDeray;
        enemy.CanAttack = true;
    }
}
