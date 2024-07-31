using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBase : MonoBehaviour
{
    [SerializeField] int hp;
    public int Hp
    {
        get { return hp; }
        set
        {
            if (value < 0) return;

            hp = value;
        }
    }

    [SerializeField] int durability;
    public int Durability
    {
        get { return durability; }
    }

    bool canDamaged = true;
    public bool CanDamaged
    {
        get { return canDamaged; }
        set { canDamaged = value; }
    }

    bool canAttack;
    public bool CanAttack
    {
        get { return canAttack; }
        set { canAttack = value; }
    }

    [SerializeField] int maxEngageAmount;
    int engageingAmount;
    public int EngagingAmount
    {
        get { return engageingAmount; }
        set { engageingAmount = value; }
    }
    public bool IsFullEngage
    {
        get { return (engageingAmount == maxEngageAmount); }
    }
}
