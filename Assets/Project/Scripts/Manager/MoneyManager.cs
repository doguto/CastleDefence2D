using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] MoneyText _moneyText;

    Money _money;
    int _addAmountPerDS = 1; //deciSecond–ˆ‚ÌMoney‘‰Á—Ê

    WaitForSeconds _addMoneyDeray;
    readonly float _derayTime = 0.1f;

    bool _canAddMoney = false;

    private void Awake()
    {
        _money = new Money();
        _addMoneyDeray = new WaitForSeconds(_derayTime);

        _money.MaxAmount = 300;
    }

    public bool CanPurchase(int cost)
    {
        return _money.Amount >= cost;
    }

    public void Purchase(int cost)
    {
        _money.UseMoney(cost);
    }

    public void StartMoney()
    {
        _canAddMoney = true;
        StartCoroutine(AddMoneyCoroutine());
    }

    IEnumerator AddMoneyCoroutine()
    {
        _money.AddMoney(_addAmountPerDS);
        _moneyText.DesplayMoney(_money.Amount, _money.MaxAmount);

        yield return _addMoneyDeray;
        
        if (_canAddMoney)
        {
            StartCoroutine(AddMoneyCoroutine());
        }
    } 
}

class Money
{
    int _amount = 0;
    public int Amount
    {
        get { return _amount; }
    }

    readonly int _MinAmount = 0;
    int _MaxAmount;
    public int MaxAmount
    {
        get { return _MaxAmount; }
        set
        {
            if (value < 0) return;
            _MaxAmount = value; 
        }
    }

    public Money()
    {
        _amount = 0;
    }

    public void AddMoney(int addAmount)
    {
        if (_amount + addAmount > _MaxAmount)
        {
            _amount = _MaxAmount;
            return;
        }
        _amount += addAmount;
    }

    public void UseMoney(int useAmount)
    {
        if (_amount - useAmount < _MinAmount)
        {
            return;
        }

        _amount -= useAmount;
    }
}