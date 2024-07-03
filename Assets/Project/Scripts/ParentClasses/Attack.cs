using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack : MonoBehaviour
{
    [SerializeField] protected int power;
    [SerializeField] protected float attackInterval;
    protected WaitForSeconds attackDeray;
}
