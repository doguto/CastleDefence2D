using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class RobotMove : MonoBehaviour
{
    [SerializeField] Ally ally; //�{��Ally�i�[�z��
    [SerializeField] Transform robotTransform; //MyTransform�i�[�ϐ�
    [SerializeField] float speed; //�ړ����x�i�[�ϐ�
    protected Vector2 nextEnemyPosition = new Vector2(0, 0); //���ړ���i�[�x�N�g��
    protected Vector3 nextEulerAngle = new Vector3(0, 0, 0); //��������i�[�p�x�N�g��
    readonly protected Vector3 leftEulerAngle = new Vector3(0, 0, 0); //��������`�x�N�g��
    readonly protected Vector3 rightEulerAngle = new Vector3(0, 180, 0); //�E������`�x�N�g��

    protected abstract void Move();
}
