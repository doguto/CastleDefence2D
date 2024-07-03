using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMove : Move　//EnemyMove抽象クラス
{
    [SerializeField] protected Enemy enemy; //本Enemy格納変数

    public abstract void Move();
}
