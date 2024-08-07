using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : AllyBase
{
    [SerializeField] float initY;
    [SerializeField] int _cost;

    Enemy targetEnemy; //目標Enemy格納変数
    public Enemy TargetEnemy
    {
        get { return targetEnemy; }
        set 
        {
            if (value == null) return;
            targetEnemy = value; 
        }
    }

    Enemy engagingEnemy; //現在接敵中のEnemy
    public Enemy EngagingEnemy
    {
        get { return engagingEnemy; }
        set
        {
            if (!value) return;
            engagingEnemy = value;
        }
    }

    EnemyDamage engagingEnemyDamage; //現在接敵中のEnemyにダメージを与える用
    public EnemyDamage EngagingEnemyDamage
    {
        get { return engagingEnemyDamage; }
        set
        {
            if (!value) return;
            engagingEnemyDamage = value;
        }
    }

    bool canMove; //動作可能性格納変数
    public bool CanMove
    {
        get { return canMove; }
        set { canMove = value;}
    }

    bool isEngage;
    public bool IsEngage
    {
        get { return isEngage; }
        set { isEngage = value; }
    }


    private void Awake()
    {
        Init();
    }

    void Init()
    {
        MoneyManager moneyManager = GameObject.Find("BattleManager").GetComponent<MoneyManager>();
        if (!moneyManager.CanPurchase(_cost))
        {
            Destroy(this.gameObject);
        }

        moneyManager.Purchase(_cost);
        UnitList.AddUnit<Soldier>(this);
        Transform myTransform = this.gameObject.transform;
        Vector2 initPosition = new Vector2(myTransform.position.x, initY);
        myTransform.position = initPosition;
    }

    public void OnGameOver()
    {
        canMove = false;
        CanAttack = false;
        this.gameObject.SetActive(false);
    }
}
