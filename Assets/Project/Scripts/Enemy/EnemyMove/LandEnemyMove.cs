using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandEnemyMove : EnemyMove
{
    [SerializeField] TargetSetter_Normal targetSetter;
    Ally tempTarget;

    private void Awake()
    {
        enemy.CanMove = true;
        enemy.IsEngage = false;
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
        tempTarget = targetSetter.SetTarget(myTransform);
        if (myTransform.position.x - tempTarget.transform.position.x > 0)
        {
            nextPosition.x -= speed * Time.deltaTime;
            if (nextPosition.x < tempTarget.transform.position.x) return;
            nextEulerAngle = leftEulerAngle;
        }
        else
        {
            nextPosition.x += speed * Time.deltaTime;
            if (nextPosition.x > tempTarget.transform.position.x) return;
            nextEulerAngle = rightEulerAngle;
        }

        myTransform.eulerAngles = nextEulerAngle;
        myTransform.position = nextPosition;
    }
}
