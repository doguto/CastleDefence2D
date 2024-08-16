using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyBase : MonoBehaviour
{
    [SerializeField] int _hp;
    public int Hp
    {
        get { return _hp; }
        set
        {
            if (value < 0) return;

            _hp = value;
        }
    }

    [SerializeField] int _durability;
    public int Durability
    {
        get { return _durability; }
    }

    bool _canDamaged = true;
    public bool CanDamaged
    {
        get { return _canDamaged; }
        set { _canDamaged = value; }
    }

    bool _canAttack;
    public bool CanAttack
    {
        get { return _canAttack; }
        set { _canAttack = value; }
    }

    [SerializeField] int _maxEngageAmount;
    int _engageingAmount;
    public int EngagingAmount
    {
        get { return _engageingAmount; }
        set { _engageingAmount = value; }
    }
    public bool IsFullEngage
    {
        get { return (_engageingAmount == _maxEngageAmount); }
    }
}
