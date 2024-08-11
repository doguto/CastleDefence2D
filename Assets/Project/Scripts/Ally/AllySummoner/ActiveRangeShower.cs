using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveRangeShower : MonoBehaviour
{
    readonly float _y = -2.6f;
    Transform _myTransform;
    readonly float _mouseZPosition = 10;

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        FollowMouse();
    }

    void Init()
    {
        _myTransform = transform;

        Vector3 initPosition = _myTransform.position;
        initPosition.y = _y;
        _myTransform.position = initPosition;
    }

    private void FollowMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = _mouseZPosition;
        Vector3 nextPosition = mousePosition;
        nextPosition.y = _y;
        _myTransform.position = mousePosition;
    }
}
