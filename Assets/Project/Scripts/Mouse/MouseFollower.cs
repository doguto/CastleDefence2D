using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseFollower : MonoBehaviour
{
    [SerializeField] Transform myTransform;
    IClicked clicked;
    bool isCollisionCheck = false;
    //bool isMouseEmpty = true;

    private void Update()
    {
        LeftClicked();
    }

    void LeftClicked()
    {
        if (!Input.GetMouseButtonDown(0)) return;

        //if (isMouseEmpty) 
        GetClicked();
        //ReleaseHoverer();
    }

    void GetClicked()
    {
        clicked = null;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        myTransform.position = mousePosition;
        isCollisionCheck = true;
    }

    //void ReleaseHoverer()
    //{

    //}

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isCollisionCheck) return;
        if (clicked != null) return;

        IClicked iclicked = collision.gameObject.GetComponent<IClicked>();
        if (iclicked == null) return;

        clicked = iclicked;
        clicked.OnClicked();
        isCollisionCheck = false;
    }
}
