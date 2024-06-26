using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NormalSoldierMove : SoldierMove
{
    Vector3 centerPosition;

    private void Awake()
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

    void ReturnToCenter()
    {
        if (myTransform.position == centerPosition) return;
        if (soldier.TargetEnemy) return;
        if (!soldier.CanMove) return;

        Move(centerPosition);
    }

    void Move(Vector3 targetPosition)
    {
        nextPosition = myTransform.position;
        if (myTransform.position.x > targetPosition.x)
        {
            nextPosition.x -= speed * Time.deltaTime;
            if (nextPosition.x < targetPosition.x)
            {
                nextPosition = targetPosition;
                return;
            }
            nextEulerAngle = leftEulerAngle;
        }
        else
        {
            nextPosition.x += speed * Time.deltaTime;
            if (nextPosition.x > targetPosition.x)
            {
                nextPosition = targetPosition;
                return;
            }
            nextEulerAngle = rightEulerAngle;
        }
        myTransform.eulerAngles = nextEulerAngle;
        myTransform.position = nextPosition;
    }
}
