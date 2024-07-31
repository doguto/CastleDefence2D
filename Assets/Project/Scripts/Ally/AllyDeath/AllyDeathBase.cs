using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyDeathBase : Death
{
    public abstract void CallDeath();

    protected abstract void Die();
}
