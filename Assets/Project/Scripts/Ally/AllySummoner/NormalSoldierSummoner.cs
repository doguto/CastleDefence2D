using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSoldierSummoner : Summoner, IClicked
{
    private void Awake()
    {
        InitialSet();
    }

    protected override void Summon()
    {
        Instantiate(summonedObject, summonerTransform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    public void OnClicked()
    {
        if (!canSummon) return;

        Summon();
    }
}
