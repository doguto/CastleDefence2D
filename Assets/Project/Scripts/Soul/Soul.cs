using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soul : MonoBehaviour
{
    [SerializeField] Transform _myTransform;
    [SerializeField] float _ceiling;
    readonly float _ascendSpeed = 5f;
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
