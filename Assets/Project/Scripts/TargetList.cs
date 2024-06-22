using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class TargetList : MonoBehaviour
{
    [SerializeField] public List<Soldier> robots = new List<Soldier>();
    [SerializeField] public Gate gate;
}
