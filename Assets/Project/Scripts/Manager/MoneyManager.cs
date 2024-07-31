using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] MoneyText _MoneyText;

    Money _Money;
    int _AddAmountPerDS = 1; //deciSecond–ˆ‚ÌMoney‘‰Á—Ê

    WaitForSeconds _AddMoneyDeray;
    readonly float _DerayTime = 0.1f;

    bool _CanAddMoney = false;

    private void Awake()
    {
        _Money = new Money();
        _AddMoneyDeray = new WaitForSeconds(_DerayTime);

        _Money.MaxAmount = 300;
    }

    public bool CanPurchase(int cost)
    {
        return _Money.Amount >= cost;
    }

    public void Purchase(int cost)
    {
        _Money.UseMoney(cost);
    }

    public void StartMoney()
    {
        _CanAddMoney = true;
        StartCoroutine(AddMoneyCoroutine());
    }

    IEnumerator AddMoneyCoroutine()
    {
        _Money.AddMoney(_AddAmountPerDS);
        _MoneyText.DesplayMoney(_Money.Amount, _Money.MaxAmount);

        yield return _AddMoneyDeray;
        
        if (_CanAddMoney)
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