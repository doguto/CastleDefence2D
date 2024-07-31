using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoldierMove : MoveBase
{
    [SerializeField] protected Soldier soldier; //–{‘ÌAllyŠi”[”z—ñ
    [SerializeField] protected SoldierCollision soldierCollision;

    protected Vector3 centerPosition;
    
    protected abstract void MoveToEnemy();

    protected abstract void ReturnToCenter();

    protected void Move(Vector3 targetPosition)
    {
        nextPosition = myTransform.position;
        if (myTransform.position.x > targetPosition.x)
        {
            nextPosition.x -= speed * Time.deltaTime;
            if (nextPosition.x < targetPosition.x)
            {
                nextPosition = targetPosition;
                soldierCollision.SetEngage(soldier.TargetEnemy);

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
                soldierCollision.SetEngage(soldier.TargetEnemy);

                return;
            }
            nextEulerAngle = rightEulerAngle;
        }
        myTransform.eulerAngles = nextEulerAngle;
        myTransform.position = nextPosition;
    }
}
