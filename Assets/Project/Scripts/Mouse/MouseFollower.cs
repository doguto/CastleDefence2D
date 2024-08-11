using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : Singleton<MouseFollower>
{
    Transform _myTransform;
    bool _isCollisionCheck = false;
    //bool isMouseEmpty = true;

    private void Start()
    {
        _myTransform = transform;
    }

    private void Update()
    {
        LeftClicked();
    }

    void LeftClicked()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        GetClicked();
    }

    void GetClicked()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        _myTransform.position = mousePosition;
        _isCollisionCheck = true;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!_isCollisionCheck) return;

        IClicked clicked = collision.gameObject.GetComponent<IClicked>();
        if (clicked == null) return;

        clicked.OnClicked();
        _isCollisionCheck = false;
    }
}
