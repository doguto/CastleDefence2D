using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemyDeath : EnemyDeath
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
