using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : AllyBase
{
    [SerializeField] float _initY;
    [SerializeField] int _cost;

    Enemy _targetEnemy; //–Ú•WEnemyŠi”[•Ï”
    public Enemy TargetEnemy
    {
        get { return _targetEnemy; }
        set 
        {
            if (value == null) return;
            _targetEnemy = value; 
        }
    }

    Enemy _engagingEnemy; //Œ»İÚ“G’†‚ÌEnemy
    public Enemy EngagingEnemy
    {
        get { return _engagingEnemy; }
        set
        {
            if (!value) return;
            _engagingEnemy = value;
        }
    }

    EnemyDamage _engagingEnemyDamage; //Œ»İÚ“G’†‚ÌEnemy‚Éƒ_ƒ[ƒW‚ğ—^‚¦‚é—p
    public EnemyDamage EngagingEnemyDamage
    {
        get { return _engagingEnemyDamage; }
        set
        {
            if (!value) return;
            _engagingEnemyDamage = value;
        }
    }

    bool _canMove; //“®ì‰Â”\«Ši”[•Ï”
    public bool CanMove
    {
        get { return _canMove; }
        set { _canMove = value;}
    }

    bool _isEngage;
    public bool IsEngage
    {
        get { return _isEngage; }
        set { _isEngage = value; }
    }


    private void Awake()
    {
        Init();
    }

    void Init()
    {
        //MoneyManager moneyManager = GameObject.Find("BattleManager").GetComponent<MoneyManager>();
        //if (!moneyManager.CanPurchase(_cost))
        //{
        //    Destroy(this.gameObject);
        //}

        //moneyManager.Purchase(_cost);
        UnitList.AddUnit<Soldier>(this);
        Transform myTransform = transform;
        Vector2 initPosition = new Vector2(myTransform.position.x, _initY);
        myTransform.position = initPosition;
    }

    public void OnGameOver()
    {
        _canMove = false;
        CanAttack = false;
        this.gameObject.SetActive(false);
    }
}
