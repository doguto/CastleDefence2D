using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CastleCollisionBase : Collision
{
    [SerializeField] protected Gate gate;
    [SerializeField] protected AllyDamageBase damage;

    //Call this method when OnTriggerEnter is erected.
    protected abstract void Collision(Collider2D collision);

    //public abstract void SetEngage(Enemy enemy);
}
