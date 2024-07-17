using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : AllyBase
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

    Enemy engagingEnemy; //Œ»İÚ“G’†‚ÌEnemy
    public Enemy EngagingEnemy
    {
        get { return engagingEnemy; }
        set
        {
            if (!value) return;
            engagingEnemy = value;
        }
    }

    EnemyDamage engagingEnemyDamage; //Œ»İÚ“G’†‚ÌEnemy‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é—p
    public EnemyDamage EngagingEnemyDamage
    {
        get { return engagingEnemyDamage; }
        set
        {
            if (!value) return;
            engagingEnemyDamage = value;
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


    private void Awake()
    {
        UnitList.AddUnit<Soldier>(this);
    }
}
