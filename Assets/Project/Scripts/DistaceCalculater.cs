using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistaceCalculater
{
    public static  float Distance(GameObject a, GameObject b)
    {
        return (Vector3.Distance(a.transform.position , b.transform.position));
    }
}
