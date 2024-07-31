using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDeath : AllyDeathBase
{
    [SerializeField] GameObject gameOverTitle;
    [SerializeField] Vector2 gameOverTitlePosition;
    bool isDead = false;

    public override void CallDeath()
    {
        this.gameObject.tag = deadTag;
        Die();
    }

    protected override void Die()
    {
        if (isDead) return;

        isDead = true;
        BreakDownEffect(); 
        Instantiate(gameOverTitle, gameOverTitlePosition, Quaternion.identity);
    }

    void BreakDownEffect()
    {
        UnitList.HideSoldiers();
    }
}
