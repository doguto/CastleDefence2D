using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSoldierSummoner : Summoner, IClicked
{
    [SerializeField] float _width;

    private void Awake()
    {
        InitialSet();
    }

    protected override void InitialSet()
    {
        width = _width;
        base.InitialSet();
    }

    public void OnClicked()
    {
        if (!canSummon) return;

        Summon();
    }
}
