using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyMove : MonoBehaviour　//EnemyMove抽象クラス
{
    [SerializeField] protected Enemy enemy;

    [SerializeField] protected float speed; //移動速度定義変数
    [SerializeField] protected Transform enemyTransform; //Transform格納変数
    protected Vector2 nextEnemyPosition = new Vector2(0,0); //仮移動先格納ベクトル
    protected Vector3 nextEulerAngle = new Vector3(0,0,0); //顔方向仮格納用ベクトル
    readonly protected Vector3 leftEulerAngle = new Vector3(0, 0, 0); //左向き定義ベクトル
    readonly protected Vector3 rightEulerAngle = new Vector3(0, 180, 0); //右向き定義ベクトル

    public abstract void Move();
}
