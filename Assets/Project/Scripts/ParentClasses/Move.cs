using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Move : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Transform myTransform; //Transform格納変数
    protected Vector2 nextPosition; //仮移動先格納ベクトル
    protected Vector3 nextEulerAngle; //顔方向仮格納用ベクトル
    readonly protected Vector3 leftEulerAngle = new Vector3(0, 0, 0); //左向き定義ベクトル
    readonly protected Vector3 rightEulerAngle = new Vector3(0, 180, 0); //右向き定義ベクトル
}
