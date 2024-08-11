using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameOverEffect : MonoBehaviour
{
    [SerializeField] float _dropSpeed;
    [SerializeField] GameObject _returnButton;
    readonly float _targetYPosition = -1;
    [SerializeField] Vector2 _returnButtonPosition;
    Transform _myTransform;

    bool _emerged;

    private void Awake()
    {
        _myTransform = transform;
        _emerged = false;
        EmergeGameOver();
    }

    private void FixedUpdate()
    {
        EmergeGameOver();
    }

    void EmergeGameOver()
    {
        if (_emerged) return;

        Vector2 nextPosition = _myTransform.position;
        nextPosition.y -= _dropSpeed * Time.deltaTime;
        _myTransform.position = nextPosition;
        if (_myTransform.position.y < _targetYPosition)
        {
            _emerged = true;
            EmergeReturnButton();
            return;
        }
    }

    void EmergeReturnButton()
    {
        Instantiate(_returnButton, _returnButtonPosition, quaternion.identity);
    }
}
