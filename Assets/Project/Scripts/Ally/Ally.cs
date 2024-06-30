using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
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
    public int Duration
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
}
