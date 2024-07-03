using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyDeath : Death
{
    public abstract void CallDeath();

    protected abstract IEnumerator Death();
}
