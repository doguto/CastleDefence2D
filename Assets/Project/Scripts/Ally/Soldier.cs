using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Ally
{
    Enemy targetEnemy; //–Ú•WEnemyŠi”[•Ï”
    public Enemy TargetEnemy
    {
        get { return targetEnemy; }
        set 
        {
            if (value == null) return;
            targetEnemy = value; 
        }
    }

    bool canMove; //“®ì‰Â”\«Ši”[•Ï”
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
