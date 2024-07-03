using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyDamage : Damage
{
    [SerializeField] protected Ally ally;
    [SerializeField] protected SpriteRenderer[] spriteRenderers;
    [SerializeField] protected float damagedEffectLength;
    protected WaitForSeconds damagedEffectDeray;

    //�_���[�W������t�֐�
    public abstract void CallDamaged(int power);

    //�_���[�W�����֐�
    protected abstract void Damaged(int damage);

    //�_���[�W�ʌv�Z�֐�
    protected abstract int DamageAmount(int power, int duration);

    protected IEnumerator DamagedEffect()
    {
        foreach (SpriteRenderer sprite in spriteRenderers)
        {
            sprite.material.color = damagedColor;
        }

        yield return damagedEffectDeray;

        foreach (SpriteRenderer sprite in spriteRenderers)
        {
            sprite.material.color = Color.white;
        }
    }
}
