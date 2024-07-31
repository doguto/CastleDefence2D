using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SordAttack : AllyAttack
{
    [SerializeField] Soldier soldier;
    Transform soldierTransform;
    [SerializeField] Vector3 slashRotateAdd;
    [SerializeField] float slashedDerayTime = 0.1f;
    WaitForSeconds slashedDeray;
    readonly string _slashSEKey = "Slash";

    private void Awake()
    {
        attackDeray = new WaitForSeconds(attackInterval);
        slashedDeray = new WaitForSeconds(slashedDerayTime);
        soldier.CanAttack = true;
        soldierTransform = transform;
    }

    private void Update()
    {
        Attack();
    }

    protected override void Attack()
    {

        if (!soldier.CanAttack) return;
        if (!soldier.IsEngage) return;
        if (!soldier.EngagingEnemy)
        {
            soldier.IsEngage = false;
            soldier.CanMove = true;
            return;
        }
        if (!soldier.EngagingEnemyDamage)
        {
            soldier.IsEngage = false;
            soldier.CanMove = true;
            return;
        }

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
        Audio.SEPlayOneShot(_slashSEKey);
        Vector3 preRotation = soldierTransform.eulerAngles;
        soldierTransform.eulerAngles = SlashRotate(preRotation);
        soldier.EngagingEnemyDamage.CallDamaged(power);

        yield return slashedDeray;

        soldierTransform.eulerAngles = preRotation;
        StartCoroutine(AttackWait());
    }


    //HelperMethod

    Vector3 SlashRotate(Vector3 preRotation)
    {
        if (soldierTransform.localEulerAngles.y == 0)
        {
            return preRotation - slashRotateAdd;
        }
        return preRotation + slashRotateAdd;
    }
}

