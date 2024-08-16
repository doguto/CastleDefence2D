using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleDeath : AllyDeathBase
{
    [SerializeField] GameObject _gameOverTitle;
    [SerializeField] Vector2 _gameOverTitlePosition;
    bool _isDead = false;

    public override void CallDeath()
    {
        this.gameObject.tag = deadTag;
        Die();
    }

    protected override void Die()
    {
        if (_isDead) return;

        _isDead = true;
        BreakDownEffect(); 
        Instantiate(_gameOverTitle, _gameOverTitlePosition, Quaternion.identity);
    }

    void BreakDownEffect()
    {
        UnitList.HideSoldiers();
    }
}
