using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SummonButtom : MonoBehaviour
{
    [SerializeField] protected GameObject summoner;

    protected MoneyManager moneyManager;
    [SerializeField] protected int cost;

    [SerializeField] protected float chargeTime;
    protected bool isFullCharge = true;
    protected bool isCharging = false;
    WaitForSeconds _chargeWait;

    [SerializeField] GameObject _backFrame;

    [SerializeField] GameObject _grayBack;
    GameObject _grayBackInstance;
    Transform _grayBackTransform;
    readonly Vector3 _grayBackScale = new Vector3(2,2,0);

    readonly float _chargingMoveAmount = 0.1f;

    readonly Vector3 _center = new Vector3(0, 0, 0);


    private void Awake()
    {
        moneyManager = GameObject.Find("BattleManager").GetComponent<MoneyManager>();
        _grayBackInstance = Instantiate(_grayBack, _backFrame.transform);
        _grayBackTransform = _grayBackInstance.transform;
        _grayBackInstance.SetActive(false);

        _chargeWait = new WaitForSeconds(chargeTime / (float)10);
    }

    protected virtual void CallSummoner()
    {
        if (!isFullCharge) return;

        if (!moneyManager.CanPurchase(cost)) return;
        moneyManager.Purchase(cost);

        Summoner _summoner = Instantiate(summoner).GetComponent<Summoner>();
        _summoner.SummonButtom = this;

        isCharging = true;
        StartSummonCharge();
    }

    protected virtual void StartSummonCharge()
    {
        isFullCharge = false;
        isCharging = true;

        _grayBackTransform.localScale = _grayBackScale;
        _grayBackTransform.localPosition = _center;

        StartCoroutine(ChargeCoroutin());
    }

    public virtual void ReturnBeforePressed()
    {
        isFullCharge = true;
        moneyManager.ReturnMoney(cost);

        _grayBackInstance.SetActive(false);
        _grayBackTransform.localPosition = _center;
    }

    IEnumerator ChargeCoroutin()
    {
        _grayBackInstance.SetActive(true);

        for (int i = 1; i <= 10; i++)
        {
            yield return _chargeWait;

            Vector3 nextScale = _grayBackScale;
            nextScale.y *= ((float)(10 - i) / 10f);
            _grayBackTransform.localScale = nextScale;
            Vector3 nextLocalPosition = _grayBackTransform.localPosition;
            nextLocalPosition.y += _chargingMoveAmount;
            _grayBackTransform.localPosition = nextLocalPosition;
        }

        _grayBackInstance.SetActive(false);
        isFullCharge = true;
    }
}
