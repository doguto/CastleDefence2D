using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandEnemyMove : EnemyMove
{
    [SerializeField] TargetSetter_Normal targetSetter;
    Ally tempTarget;

    private void Awake()
    {
        enemy.Movable = true;
        enemy.IsEngage = false;
    }
    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        if (!enemy.Movable) return;
        if (enemy.IsEngage) return;

        nextEnemyPosition = enemyTransform.position;
        tempTarget = targetSetter.SetTarget(enemyTransform);
        if (enemyTransform.position.x - tempTarget.transform.position.x > 0)
        {
            nextEnemyPosition.x -= speed * Time.deltaTime;
            if (nextEnemyPosition.x < tempTarget.transform.position.x) return;
            nextEulerAngle = leftEulerAngle;
        }
        else
        {
            nextEnemyPosition.x += speed * Time.deltaTime;
            if (nextEnemyPosition.x > tempTarget.transform.position.x) return;
            nextEulerAngle = rightEulerAngle;
        }

        enemyTransform.eulerAngles = nextEulerAngle;
        enemyTransform.position = nextEnemyPosition;
    }
}
