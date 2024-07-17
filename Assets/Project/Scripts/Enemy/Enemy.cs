using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp;
    public int Hp
    {
        get { return hp; }
        set { hp = value; }
    }

    AllyBase engagingAlly;
    public AllyBase EngagingAlly
    {
        get { return engagingAlly; }
        set { engagingAlly = value; }
    }

    int duration;
    public int Duration
    {
        get { return duration; }
    }

    AllyDamage engagingAllyDamage;
    public AllyDamage EngagingAllyDamage
    {
        get { return engagingAllyDamage; }
        set { engagingAllyDamage = value; }
    }

    private bool canMove = true; //����\���i�[�ϐ�
    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value; }
    }

    private bool canAttack = true; //�U���\���i�[�ϐ�
    public bool CanAttack
    {
        get { return canAttack; }
        set { canAttack = value; }
    }

    private bool canDamaged; //��e�\���i�[�ϐ�
    public bool CanDamaged
    {
        get { return canDamaged; }
        set { canDamaged = value; }
    }

    private bool isEngage = false; //�ړG���i�U�����j 
    public bool IsEngage
    {
        get { return isEngage; }
        set
        { 
            if (value)
            {
                CanMove = false;
            }
            isEngage = value;
        }
    }

    private void Awake()
    {
        UnitList.AddUnit<Enemy>(this);
    }
}
