using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class TargetList : MonoBehaviour
{
    [SerializeField] public List<Robot> robots = new List<Robot>();
    [SerializeField] public Gate gate;
}
