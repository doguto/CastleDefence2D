using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandSoldierActiveRange : AllyActiveRange
{
    private void FixedUpdate()
    {
        TargetSetter(centerPosition, width);
    }

    protected override void TargetSetter(Vector2 centerPosition, float width)
    {
        if (soldier.IsEngage) return;
        if (width == 0) return;
        if (soldier.TargetEnemy) return;

        Enemy tempTarget = UnitList.GetTargetEnemy(centerPosition, width);

        if (!tempTarget) return;

        soldier.TargetEnemy = tempTarget;
    }
}
