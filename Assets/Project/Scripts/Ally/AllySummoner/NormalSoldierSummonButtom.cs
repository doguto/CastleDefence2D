using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSoldierSummonButtom : SummonButtom, IClicked
{
    public void OnClicked()
    {
        CallSummoner();
    }
}
