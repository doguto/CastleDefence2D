using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyDamageBase : DamageBase
{
    [SerializeField] protected AllyBase ally;
    [SerializeField] protected AllyDeathBase allyDeath;
    [SerializeField] protected SpriteRenderer[] spriteRenderers;
    readonly protected float damagedEffectLength = 0.2f;
    protected WaitForSeconds damagedEffectDeray;

    protected void Awake()
    {
        damagedEffectDeray = new WaitForSeconds(damagedEffectLength);
    }

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
