using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMoveBase : MoveBase�@//EnemyMove���ۃN���X
{
    [SerializeField] protected Enemy enemy; //�{Enemy�i�[�ϐ�

    public abstract void Move();
}
