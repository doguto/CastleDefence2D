using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Summoner : MonoBehaviour
{
    [SerializeField] protected GameObject summonedObject;
    [SerializeField] protected GameObject activeRange;

    protected bool canSummon = false;

    protected Transform summonerTransform;
    [SerializeField] protected SpriteRenderer[] spriteRenderer;

    readonly int _mouseZPosition = 10;
    readonly protected Vector2 TopRightLimit = new Vector2(12,4);
    readonly protected Vector2 BottomLeftLimit = new Vector2(-10, -8);
    protected abstract void Summon();


    protected void Update()
    {
        FollowMouse();
        CheckSummonCondition();
    }
    protected virtual void InitialSet()
    {
        summonerTransform = transform;
        Instantiate(activeRange);
    }

    private void FollowMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = _mouseZPosition;
        summonerTransform .position = mousePosition;
    } 

    private void CheckSummonCondition()
    {
        if (IsIn.Vector2Range(BottomLeftLimit, TopRightLimit, summonerTransform.position))
        {
            foreach (var sprite in spriteRenderer)
            {
                sprite.material.color = Color.white;
            }

            canSummon = true;
            return;
        }

        canSummon = false;
        foreach (var sprite in spriteRenderer)
        {
            sprite.material.color = Color.gray;
        }
    }
}
