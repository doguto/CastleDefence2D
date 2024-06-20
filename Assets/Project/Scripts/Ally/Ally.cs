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

    [SerializeField] int duration;
    public int Duration
    {
        get { return duration; }
    }

    bool canDamaged = true;
    public bool CanDamaged
    {
        get { return canDamaged; }
        set { canDamaged = value; }
    }
}
