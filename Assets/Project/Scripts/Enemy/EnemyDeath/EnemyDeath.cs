using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyDeath : Death
{
    [SerializeField] protected GameObject enemySoul;
    [SerializeField] protected Enemy enemy;
    public abstract void CallDeath();

    protected abstract void Death();
}
