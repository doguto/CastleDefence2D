using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hp;
    public Ally engagingAlly;
    public AllyHpManager engagingAllyCollision;

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
