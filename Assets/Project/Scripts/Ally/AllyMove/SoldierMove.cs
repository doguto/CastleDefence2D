using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoldierMove : Move
{
    [SerializeField] protected Soldier soldier; //�{��Ally�i�[�z��

    protected abstract void MoveToEnemy();
}
