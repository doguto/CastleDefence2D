using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetSetter_Normal : MonoBehaviour
{
    [SerializeField] TargetList _targetList;

    public AllyBase SetTarget(Transform enemyTransform)
    {
        if (_targetList.robots == null)
        {
            return _targetList.gate;
        }

        AllyBase target = null;
        float tempDistance = 0;
        float finalDistance = 0;
        float minDistance = 0;

        foreach (Soldier robot in _targetList.robots)
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
        finalDistance = (enemyTransform.position - _targetList.gate.transform.position).sqrMagnitude;

        if (finalDistance < minDistance)
        {
            target = _targetList.gate;
        }

        return target;
    }
}
