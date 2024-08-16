using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandEnemyMove : EnemyMoveBase
{
    AllyBase _target;

    private void Start()
    {
        enemy.CanMove = true;
        enemy.IsEngage = false;

        _target = UnitList.SetGate();
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
        if (myTransform.position.x - _target.transform.position.x > 0)
        {
            nextPosition.x -= speed * Time.deltaTime;
            if (nextPosition.x < _target.transform.position.x) return;
            nextEulerAngle = leftEulerAngle;
        }
        else
        {
            nextPosition.x += speed * Time.deltaTime;
            if (nextPosition.x > _target.transform.position.x) return;
            nextEulerAngle = rightEulerAngle;
        }

        myTransform.eulerAngles = nextEulerAngle;
        myTransform.position = nextPosition;
    }
}
