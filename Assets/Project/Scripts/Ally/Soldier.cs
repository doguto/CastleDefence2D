using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : AllyBase
{
    Enemy targetEnemy; //�ڕWEnemy�i�[�ϐ�
    public Enemy TargetEnemy
    {
        get { return targetEnemy; }
        set 
        {
            if (value == null) return;
            targetEnemy = value; 
        }
    }

    Enemy engagingEnemy; //���ݐړG����Enemy
    public Enemy EngagingEnemy
    {
        get { return engagingEnemy; }
        set
        {
            if (!value) return;
            engagingEnemy = value;
        }
    }

    EnemyDamage engagingEnemyDamage; //���ݐړG����Enemy�Ƀ_���[�W��^����p
    public EnemyDamage EngagingEnemyDamage
    {
        get { return engagingEnemyDamage; }
        set
        {
            if (!value) return;
            engagingEnemyDamage = value;
        }
    }

    bool canMove; //����\���i�[�ϐ�
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
