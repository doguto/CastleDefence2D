using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSoldierDeath : AllyDeath
{
    public override void CallDeath()
    {
        Death();
    }

    protected override IEnumerator Death()
    {
        yield return 0;
    }
}
