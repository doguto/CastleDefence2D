using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Summoner : MonoBehaviour
{
    [SerializeField] protected GameObject summonedObject;

    protected bool canSummon = false;

    [SerializeField] protected Transform summonerTransform;
    [SerializeField] protected SpriteRenderer[] spriteRenderer;

    [SerializeField] int mouseZPosition;
    [SerializeField] protected Vector2 TopRightLimit;
    [SerializeField] protected Vector2 BottomLeftLimit;
    protected abstract void Summon();

    protected abstract void InitialSet();

    protected void Update()
    {
        FollowMouse();
        CheckSummonCondition();
    }

    private void FollowMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = mouseZPosition;
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
