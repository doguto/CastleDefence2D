using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyDamage : Damage
{
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected float damagedEffectLength;
    protected WaitForSeconds damagedEffectDeray;

    //ダメージ処理受付関数
    public abstract void CallDamaged(int power);

    //ダメージ処理関数
    protected abstract void Damaged(int damage);

    //ダメージ量計算関数
    protected abstract int DamageAmount(int power, int duration);

    //赤く一度点滅させる関数
    protected IEnumerator DamagedEffect() 
    {
        spriteRenderer.material.color = damagedColor;

        yield return damagedEffectDeray;

        spriteRenderer.material.color = Color.white;
    }
}
