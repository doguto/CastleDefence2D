using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    [SerializeField] Transform myTransform;
    [SerializeField] float ceiling;
    readonly float ascendSpeed = 5f;
    private void Update()
    {
        Ascend();
    }

    private void Ascend()
    {
        Vector3 nextPosition = myTransform.position;
        nextPosition.y += ascendSpeed * Time.deltaTime;
        myTransform.position = nextPosition;

        if (myTransform.position.y >= ceiling)
        {
            Destroy(this.gameObject);
        }
    }


}
