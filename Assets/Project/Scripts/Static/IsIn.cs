using System.Collections;
using System.Collections.Generic;
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
