using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Death : MonoBehaviour
{
    [SerializeField] protected Transform myTransform;
    //[SerializeField] protected float deathDerayTime;
    //protected WaitForSeconds deathDeray;
    protected readonly string deadTag = "Dead";

    //protected void Awake()
    //{
    //    deathDeray = new WaitForSeconds(deathDerayTime);
    //}
}
