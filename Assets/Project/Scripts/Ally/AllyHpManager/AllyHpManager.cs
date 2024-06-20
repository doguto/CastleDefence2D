using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyHpManager : MonoBehaviour
{
    [SerializeField] protected Ally ally;
    protected Color damagedColor = new Color32(255, 153, 153, 255);

    //�_���[�W������t�֐�
    public abstract void CallDamaged(int power);

    //�_���[�W�����֐�
    protected abstract void Dameged(int damage);

    protected abstract int DamageAmount(int power, int duration);

}
