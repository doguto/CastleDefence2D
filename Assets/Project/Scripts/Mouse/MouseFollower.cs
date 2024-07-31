using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : Singleton<MouseFollower>
{
    Transform myTransform;
    bool isCollisionCheck = false;
    //bool isMouseEmpty = true;

    private void Start()
    {
        myTransform = transform;
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
        myTransform.position = mousePosition;
        isCollisionCheck = true;
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isCollisionCheck) return;

        IClicked clicked = collision.gameObject.GetComponent<IClicked>();
        if (clicked == null) return;

        clicked.OnClicked();
        isCollisionCheck = false;
    }
}
