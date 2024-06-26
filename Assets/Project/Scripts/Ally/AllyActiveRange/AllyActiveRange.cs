using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyActiveRange : MonoBehaviour
{
    [SerializeField] protected TargetEnemies targetEnemies;
    [SerializeField] protected Soldier soldier;
    [SerializeField] protected Vector2 centerPosition;
    [SerializeField] protected float width;

    readonly protected string enemyTag = "Enemy";

    protected abstract void TargetSetter(Vector2 centerPosition, float width);

    protected bool IsInTargetEnemies(Enemy enemy)
    {
        if (!enemy) return false;

        if (targetEnemies.ContainTarget(enemy)) return true;
        return false;
    }

    protected void Awake()
    {
        this.transform.parent = null;
    }
}