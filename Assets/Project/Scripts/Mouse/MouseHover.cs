using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHover : MonoBehaviour
{
    [SerializeField] Transform myTransform;
    bool isSetMode = false;

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
        if (!isSetMode) return;

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        myTransform.position = mousePosition;
    }

    void ChangeMode()
    {
        isSetMode = !isSetMode;
    }
}
