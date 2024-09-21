using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Transform _myTransform;
    readonly float _leftFace = 0;
    readonly float _rightFace = 180;


    [SerializeField] int _hp;
    public int Hp
    {
        get { return _hp; }
        set { _hp = value; }
    }

    AllyBase _engagingAlly;
    public AllyBase EngagingAlly
    {
        get { return _engagingAlly; }
        set
        {
            if (value == null) return;
            if (this.gameObject == null) return;

            Vector3 euler = _myTransform.eulerAngles;
            if (value.gameObject.transform.position.x < _myTransform.position.x)
            {
                euler.y = _leftFace;
            }
            else
            {
                euler.y = _rightFace;
            }
            _myTransform.eulerAngles = euler;

            _engagingAlly = value;
        }
    }

    int _duration;
    public int Duration
    {
        get { return _duration; }
    }

    AllyDamageBase _engagingAllyDamage;
    public AllyDamageBase EngagingAllyDamage
    {
        get { return _engagingAllyDamage; }
        set { _engagingAllyDamage = value; }
    }

    private bool _canMove = true; //“®ì‰Â”\«Ši”[•Ï”
    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    private bool _canAttack = true; //UŒ‚‰Â”\«Ši”[•Ï”
    public bool CanAttack
    {
        get { return _canAttack; }
        set { _canAttack = value; }
    }

    private bool _canDamaged; //”í’e‰Â”\«Ši”[•Ï”
    public bool CanDamaged
    {
        get { return _canDamaged; }
        set { _canDamaged = value; }
    }

    private bool _isEngage = false; //Ú“G’†iUŒ‚’†j 
    public bool IsEngage
    {
        get { return _isEngage; }
        set
        { 
            if (value)
            {
                CanMove = false;
            }
            _isEngage = value;
        }
    }
    
    private void Awake()
    {
        _myTransform = transform;
        UnitList.AddUnit<Enemy>(this);
    }

    /**
     *  This Start() is for a Test Mode.
     *  In other time, please comment out this function, 
     * and please uncomment out Awake() function.
     */
    /*
    private void Start()
    {
        _myTransform = transform;
        UnitList.AddUnit<Enemy>(this);
    }*/
}
