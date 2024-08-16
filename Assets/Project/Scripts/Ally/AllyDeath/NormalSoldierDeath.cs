using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class NormalSoldierDeath : AllyDeathBase
{
    [SerializeField] Soldier _soldier;
    [SerializeField] GameObject _soul;


    public override void CallDeath()
    {
        _soldier.CanAttack = false;
        _soldier.CanDamaged = false;
        _soldier.CanMove = false;
        this.gameObject.tag = deadTag;

        Die();
    }

    protected override void Die()
    {
        Instantiate(_soul,myTransform.position,Quaternion.identity);
        UnitList.RemoveUnit<Soldier>(_soldier);
        Destroy(this.gameObject);
    }
}
