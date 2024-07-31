using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandEnemyMove : EnemyMoveBase
{
    AllyBase target;

    private void Start()
    {
        enemy.CanMove = true;
        enemy.IsEngage = false;

        target = UnitList.SetGate();
    }

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (!enemy.CanMove) return;
        if (enemy.IsEngage) return;

        nextPosition = myTransform.position;
        if (myTransform.position.x - target.transform.position.x > 0)
        {
            nextPosition.x -= speed * Time.deltaTime;
            if (nextPosition.x < target.transform.position.x) return;
            nextEulerAngle = leftEulerAngle;
        }
        else
        {
            nextPosition.x += speed * Time.deltaTime;
            if (nextPosition.x > target.transform.position.x) return;
            nextEulerAngle = rightEulerAngle;
        }

        myTransform.eulerAngles = nextEulerAngle;
        myTransform.position = nextPosition;
    }
}
