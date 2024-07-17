using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyDamage : DamageBase
{
    [SerializeField] protected AllyBase ally;
    [SerializeField] protected AllyDeath allyDeath;
    [SerializeField] protected SpriteRenderer[] spriteRenderers;
    [SerializeField] protected float damagedEffectLength;
    protected WaitForSeconds damagedEffectDeray;

    //ダメージ処理受付関数
    public abstract void CallDamaged(int power);

    //ダメージ処理関数
    protected abstract void Damaged(int damage);

    //ダメージ量計算関数
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
