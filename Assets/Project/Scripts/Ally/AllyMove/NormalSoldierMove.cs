using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NormalSoldierMove : SoldierMove
{
    private void Start()
    {
        centerPosition = transform.position;
        soldier.CanMove = true;
        soldier.IsEngage = false;
    }

    private void Update()
    {
        MoveToEnemy();
        ReturnToCenter();
    }

    protected override void MoveToEnemy()
    {
        if (!soldier.CanMove) return;
        if (soldier.IsEngage) return;
        if (!soldier.TargetEnemy) return;

        Vector3 targetPosition = soldier.TargetEnemy.transform.position;
        Move(targetPosition);
    }

    protected override void ReturnToCenter()
    {
        if (myTransform.position == centerPosition) return;
        if (soldier.TargetEnemy) return;
        if (!soldier.CanMove) return;

        Move(centerPosition);
    }
}
