using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SordAttack : AllyAttack
{
    [SerializeField] Soldier soldier;
    [SerializeField] Transform soldierTransform;
    [SerializeField] Vector3 slashRotateAdd;
    [SerializeField] float slashedDerayTime = 0.1f;
    WaitForSeconds slashedDeray;
    private void Awake()
    {
        attackDeray = new WaitForSeconds(attackInterval);
        slashedDeray = new WaitForSeconds(slashedDerayTime);
        soldier.CanAttack = true;
    }

    private void Update()
    {
        Attack();
    }

    protected override void Attack()
    {

        if (!soldier.CanAttack) return;
        if (!soldier.IsEngage) return;

        soldier.CanAttack = false;
        StartCoroutine(Slach());
    }

    protected override IEnumerator AttackWait()
    {
        yield return attackDeray;
        soldier.CanAttack = true;
    }

    IEnumerator Slach()
    {
        Vector3 preRotation = soldierTransform.eulerAngles;
        Vector3 postRotation;
        if (soldierTransform.eulerAngles.y == 0)
        {
            postRotation = preRotation - slashRotateAdd;
        }
        else
        {
            postRotation = preRotation + slashRotateAdd;
        }
        soldierTransform.eulerAngles = postRotation;
        soldier.EngagingEnemyDamage.CallDamaged(power);

        yield return slashedDeray;

        soldierTransform.eulerAngles = preRotation;
        StartCoroutine(AttackWait());
    }
}

