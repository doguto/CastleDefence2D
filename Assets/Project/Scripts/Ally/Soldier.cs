using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Ally
{
    Enemy targetEnemy; //ฺWEnemyi[ฯ
    public Enemy TargetEnemy
    {
        get { return targetEnemy; }
        set 
        {
            if (value == null) return;
            targetEnemy = value; 
        }
    }

    bool canMove; //ฎ์ย\ซi[ฯ
    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value;}
    }

    bool isEngage;
    public bool IsEngage
    {
        get { return isEngage; }
        set { isEngage = value; }
    }
}
