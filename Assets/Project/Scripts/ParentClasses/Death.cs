using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Death : MonoBehaviour
{
    [SerializeField] protected Transform myTransform;
    [SerializeField] protected float deathDerayTime;
    protected WaitForSeconds deathDeray;
}
