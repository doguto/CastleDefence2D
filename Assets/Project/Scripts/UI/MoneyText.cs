using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _moneyText;

    public void DesplayMoney(int currentAmount, int maxAmount)
    {
        //int amount = _MoneyManager.MoneyAmount;
        //int maxAmount = _MoneyManager.MaxMoneyAmount;
        _moneyText.text = string.Format("$" + currentAmount + "/$" + maxAmount);
    }

}

