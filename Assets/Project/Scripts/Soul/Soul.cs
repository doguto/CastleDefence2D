using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    Transform _myTransform;
    readonly float _ceiling = 10;
    readonly float _ascendSpeed = 5f;

    private void Awake()
    {
        _myTransform = transform;
    }

    private void Update()
    {
        Ascend();
    }

    private void Ascend()
    {
        Vector3 nextPosition = _myTransform.position;
        nextPosition.y += _ascendSpeed * Time.deltaTime;
        _myTransform.position = nextPosition;

        if (_myTransform.position.y >= _ceiling)
        {
            Destroy(this.gameObject);
        }
    }


}
