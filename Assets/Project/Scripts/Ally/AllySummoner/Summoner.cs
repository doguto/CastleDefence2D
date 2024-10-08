using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Summoner : MonoBehaviour
{
    [SerializeField] protected GameObject summonedObject;
    [SerializeField] protected GameObject activeRange;
    protected GameObject instantiatedActiveRange;
    protected SummonButtom summonButtom;
    public SummonButtom SummonButtom 
    {
        set { summonButtom = value; }
    }

    protected Transform summonerTransform;
    [SerializeField] protected SpriteRenderer[] spriteRenderer;

    protected bool canSummon = false;

    protected float width;

    readonly int _mouseZPosition = 10;
    readonly protected Vector2 TopRightLimit = new Vector2(12,4);
    readonly protected Vector2 BottomLeftLimit = new Vector2(-10, -8);


    protected void Update()
    {
        FollowMouse();
        CheckSummonCondition();
    }
    protected virtual void InitialSet()
    {
        summonerTransform = transform;
        instantiatedActiveRange = Instantiate(activeRange);
        RangeDrawer rangeDrawer = instantiatedActiveRange.GetComponent<RangeDrawer>();
        rangeDrawer.SetWidth(width);
    }

    protected virtual void Summon()
    {
        Instantiate(summonedObject, summonerTransform.position, Quaternion.identity);
        Destroy(instantiatedActiveRange);
        Destroy(this.gameObject);
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
