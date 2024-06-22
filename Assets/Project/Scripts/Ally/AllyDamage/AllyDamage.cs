using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyDamage : MonoBehaviour
{
    [SerializeField] protected Ally ally;
    protected Color damagedColor = new Color32(255, 153, 153, 255);

    //ダメージ処理受付関数
    public abstract void CallDamaged(int power);

    //ダメージ処理関数
    protected abstract void Damaged(int damage);

    //ダメージ量計算関数
    protected abstract int DamageAmount(int power, int duration);

}
