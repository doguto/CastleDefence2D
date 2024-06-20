using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AllyDeath : MonoBehaviour
{
    [SerializeField] Enemy enemy;

    protected abstract void Death();
}
