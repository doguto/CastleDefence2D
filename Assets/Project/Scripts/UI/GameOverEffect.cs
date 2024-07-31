using NUnit.Framework.Internal;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameOverEffect : MonoBehaviour
{
    [SerializeField] float dropSpeed;
    [SerializeField] GameObject ReturnButton;
    readonly float targetYPosition = -1;
    [SerializeField] Vector2 returnButtonPosition;
    Transform myTransform;

    bool _Emerged;

    private void Awake()
    {
        myTransform = transform;
        _Emerged = false;
        EmergeGameOver();
    }

    private void FixedUpdate()
    {
        EmergeGameOver();
    }

    void EmergeGameOver()
    {
        if (_Emerged) return;

        Vector2 nextPosition = myTransform.position;
        nextPosition.y -= dropSpeed * Time.deltaTime;
        myTransform.position = nextPosition;
        if (myTransform.position.y < targetYPosition)
        {
            _Emerged = true;
            EmergeReturnButton();
            return;
        }
    }

    void EmergeReturnButton()
    {
        Instantiate(ReturnButton, returnButtonPosition, quaternion.identity);
    }
}
