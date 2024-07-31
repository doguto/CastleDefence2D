using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyActiveRange : MonoBehaviour
{
    //[SerializeField] protected TargetEnemies targetEnemies;
    [SerializeField] protected Soldier soldier;
    protected Vector2 centerPosition;
    [SerializeField] protected float width;

    readonly protected string enemyTag = "Enemy";

    protected abstract void TargetSet(Vector2 centerPosition, float width);

    protected bool IsInTargetEnemies(Enemy enemy)
    {
        if (!enemy) return false;

        if (UnitList.IsContainUnit<Enemy>(enemy)) return true;
        return false;
    }

    protected void Awake()
    {
        this.transform.parent = null;
        centerPosition = transform.position;
    }
}
