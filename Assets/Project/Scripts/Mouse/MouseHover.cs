using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    [SerializeField] Transform _myTransform;
    bool _isSetMode = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ChangeMode();
        }

        FollowMouse();
    }

    void FollowMouse()
    {
        if (!_isSetMode) return;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        _myTransform.position = mousePosition;
    }

    void ChangeMode()
    {
        _isSetMode = !_isSetMode;
    }
}
