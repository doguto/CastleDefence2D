using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyDamage : Damage
{
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected float damagedEffectLength;
    protected WaitForSeconds damagedEffectDeray;

    //�_���[�W������t�֐�
    public abstract void CallDamaged(int power);

    //�_���[�W�����֐�
    protected abstract void Damaged(int damage);

    //�_���[�W�ʌv�Z�֐�
    protected abstract int DamageAmount(int power, int duration);

    //�Ԃ���x�_�ł�����֐�
    protected IEnumerator DamagedEffect() 
    {
        spriteRenderer.material.color = damagedColor;

        yield return damagedEffectDeray;

        spriteRenderer.material.color = Color.white;
    }
}
