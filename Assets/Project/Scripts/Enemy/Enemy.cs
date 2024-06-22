using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp;
    Ally engagingAlly;
    public Ally EngagingAlly
    {
        get { return engagingAlly; }
        set 
        {
            if (value == null) return;
            engagingAlly = value;
        }
    }

    AllyDamage engagingAllyDamage;
    public AllyDamage EngagingAllyDamage
    {
        get { return engagingAllyDamage; }
        set 
        {
            if (value == null) return;
            engagingAllyDamage = value;
        }
    }

    private bool movable = true; //����\���i�[�ϐ�
    public bool Movable
    {
        get { return movable; }
        set { movable = value; }
    }

    private bool attackable = true; //�U���\���i�[�ϐ�
    public bool Attackable
    {
        get { return attackable; }
        set { attackable = value; }
    }

    private bool isEngage = false; //�ړG���i�U�����j 
    public bool IsEngage
    {
        get { return isEngage; }
        set { isEngage = value; }
    }
}
