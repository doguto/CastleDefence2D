using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public static class IsIn
{ 
    public static bool Vector2Range(Vector2 leftBottom, Vector2 rightTop, Vector2 myPosition)
    {
        bool xDimention = (leftBottom.x < myPosition.x && myPosition.x < rightTop.x);
        bool yDimention = (leftBottom.y < myPosition.y && myPosition.y < rightTop.y);

        return xDimention && yDimention;
    }
}
public static class Movement
{
    public static float Round(float targetPoint, float nextPoint, bool isFromPositive)
    {
        if (isFromPositive)
        {
            if (nextPoint < targetPoint)
            {
                nextPoint = targetPoint;
            }
        }
        else
        {
            if (nextPoint > targetPoint)
            {
                nextPoint = targetPoint;
            }
        }
        return nextPoint;
    }
}



