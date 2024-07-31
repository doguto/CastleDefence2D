using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MoneyText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _MoneyText;

    public void DesplayMoney(int currentAmount, int maxAmount)
    {
        //int amount = _MoneyManager.MoneyAmount;
        //int maxAmount = _MoneyManager.MaxMoneyAmount;
        _MoneyText.text = string.Format("$" + currentAmount + "/$" + maxAmount);
    }

}

