using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public abstract class Move : MonoBehaviour
{
    [SerializeField] protected float speed;
    [SerializeField] protected Transform myTransform; //Transform�i�[�ϐ�
    protected Vector2 nextPosition; //���ړ���i�[�x�N�g��
    protected Vector3 nextEulerAngle; //��������i�[�p�x�N�g��
    readonly protected Vector3 leftEulerAngle = new Vector3(0, 0, 0); //��������`�x�N�g��
    readonly protected Vector3 rightEulerAngle = new Vector3(0, 180, 0); //�E������`�x�N�g��
}
