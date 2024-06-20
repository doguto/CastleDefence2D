using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalRobotHpManager : AllyHpManager
{
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] float damagedEffectLength;
    WaitForSeconds damagedEffectDeray;

    private void Awake()
    {
        damagedEffectDeray = new WaitForSeconds(damagedEffectLength);
    }

    public override void CallDamaged(int power)
    {
        if (!ally.CanDamaged) return;
        if (power <= 0) return;

        Dameged(DamageAmount(power, ally.Duration));
    }

    protected override void Dameged(int damage)
    {
        if (ally.Hp - damage <= 0)
        {
            ally.Hp = 0;
            //Death();
        }
        ally.Hp -= damage;
        StartCoroutine(DamagedEffect());
    }

    IEnumerator DamagedEffect()
    {
        spriteRenderer.material.color = damagedColor;
        yield return damagedEffectDeray;
        spriteRenderer.material.color = Color.white;
    }

    protected override int DamageAmount(int power, int duration)
    {
        if (power - duration < 0)
        {
            return 0;
        }
        return power - duration;
    }
}
