using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyDamage : DamageBase
{
    [SerializeField] protected Enemy enemy;
    [SerializeField] protected EnemyDeath enemyDeath;
    [SerializeField] protected SpriteRenderer spriteRenderer;
    [SerializeField] protected float damagedEffectLength;
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
    protected int DamageAmount(int power, int duration)
    {
        if (power - duration < 0)
        {
            return 0;
        }
        return power - duration;
    }

    //赤く一度点滅させる関数
    protected IEnumerator DamagedEffect() 
    {
        spriteRenderer.material.color = damagedColor;

        yield return damagedEffectDeray;

        spriteRenderer.material.color = Color.white;
    }
}
