using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyCollision : MonoBehaviour
{
    [SerializeField] protected Enemy enemy;
    readonly protected string robotTag = "Robot";
    readonly protected string gateTag = "Gate";
}
