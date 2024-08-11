using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeDrawer : MonoBehaviour
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
        FollowMouseButtom();
    }

    void Init()
    {
        _myTransform = transform;

        Vector3 initPosition = _myTransform.position;
        initPosition.y = _y;
        _myTransform.position = initPosition;
    }

    public void SetWidth(float width)
    {
        if (width <= 0)
        {
            Debug.LogWarning("Please set width in summoner upper than 0");
            return;
        }

        Vector3 scale = _myTransform.localScale;
        scale.x = width;
        _myTransform.localScale = scale;
    }

    private void FollowMouseButtom()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = _mouseZPosition;
        Vector3 nextPosition = mousePosition;
        nextPosition.y = _y;
        _myTransform.position = nextPosition;
    }
}
