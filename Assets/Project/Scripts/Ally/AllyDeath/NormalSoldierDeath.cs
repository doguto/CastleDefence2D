using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class NormalSoldierDeath : AllyDeath
{
    [SerializeField] Soldier soldier;
    [SerializeField] GameObject soul;


    public override void CallDeath()
    {
        soldier.CanAttack = false;
        soldier.CanDamaged = false;
        soldier.CanMove = false;
        this.gameObject.tag = deadTag;

        Die();
    }

    protected override void Die()
    {
        Instantiate(soul,myTransform.position,Quaternion.identity);
        UnitList.RemoveUnit<Soldier>(soldier);
        Destroy(this.gameObject);
    }
}
