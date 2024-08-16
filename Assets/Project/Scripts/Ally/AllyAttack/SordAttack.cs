using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SordAttack : AllyAttack
{
    [SerializeField] Soldier _soldier;
    Transform _soldierTransform;
    [SerializeField] Vector3 _slashRotateAdd;
    [SerializeField] float _slashedDerayTime = 0.1f;
    WaitForSeconds _slashedDeray;
    readonly string _slashSEKey = "Slash";

    private void Awake()
    {
        attackDeray = new WaitForSeconds(attackInterval);
        _slashedDeray = new WaitForSeconds(_slashedDerayTime);
        _soldier.CanAttack = true;
        _soldierTransform = transform;
    }

    private void Update()
    {
        Attack();
    }

    protected override void Attack()
    {

        if (!_soldier.CanAttack) return;
        if (!_soldier.IsEngage) return;
        if (!_soldier.EngagingEnemy)
        {
            _soldier.IsEngage = false;
            _soldier.CanMove = true;
            return;
        }
        if (!_soldier.EngagingEnemyDamage)
        {
            _soldier.IsEngage = false;
            _soldier.CanMove = true;
            return;
        }

        _soldier.CanAttack = false;
        StartCoroutine(Slach());
    }

    protected override IEnumerator AttackWait()
    {
        yield return attackDeray;
        _soldier.CanAttack = true;
    }

    IEnumerator Slach()
    {
        Audio.SEPlayOneShot(_slashSEKey);
        Vector3 preRotation = _soldierTransform.eulerAngles;
        _soldierTransform.eulerAngles = SlashRotate(preRotation);
        _soldier.EngagingEnemyDamage.CallDamaged(power);

        yield return _slashedDeray;

        _soldierTransform.eulerAngles = preRotation;
        StartCoroutine(AttackWait());
    }


    //HelperMethod

    Vector3 SlashRotate(Vector3 preRotation)
    {
        if (_soldierTransform.localEulerAngles.y == 0)
        {
            return preRotation - _slashRotateAdd;
        }
        return preRotation + _slashRotateAdd;
    }
}

