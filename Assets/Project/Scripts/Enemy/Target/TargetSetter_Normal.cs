using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSetter_Normal : MonoBehaviour
{
    [SerializeField] TargetList targetList;

    public Ally SetTarget(Transform enemyTransform)
    {
        if (targetList.robots == null)
        {
            return targetList.gate;
        }

        Ally target = null;
        float tempDistance = 0;
        float finalDistance = 0;
        float minDistance = 0;

        foreach (Soldier robot in targetList.robots)
        {
            tempDistance = (enemyTransform.position - robot.transform.position).sqrMagnitude;
            if (minDistance == 0)
            {
                minDistance = tempDistance;
                target = robot;
                continue;
            }

            if(tempDistance < minDistance)
            {
                minDistance = tempDistance;
                target = robot;
            }
        }
        finalDistance = (enemyTransform.position - targetList.gate.transform.position).sqrMagnitude;

        if (finalDistance < minDistance)
        {
            target = targetList.gate;
        }

        return target;
    }
}
