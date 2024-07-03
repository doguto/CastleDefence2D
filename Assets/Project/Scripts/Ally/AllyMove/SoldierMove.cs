using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SoldierMove : Move
{
    [SerializeField] protected Soldier soldier; //–{‘ÌAllyŠi”[”z—ñ
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
