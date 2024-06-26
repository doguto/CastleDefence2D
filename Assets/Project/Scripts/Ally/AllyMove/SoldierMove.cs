using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoldierMove : Move
{
    [SerializeField] protected Soldier soldier; //–{‘ÌAllyŠi”[”z—ñ

    protected abstract void MoveToEnemy();
}
