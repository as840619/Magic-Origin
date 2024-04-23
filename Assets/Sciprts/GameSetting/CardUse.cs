using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class CardUse : MonoBehaviour
{
    // public bool cardn = false;   //cardn = true;
    [SerializeField] ActionType actionType;
    PlayerAttack Pa => PlayerController.Instance.GetComponentInChildren<PlayerAttack>();
    int staminaValue => PlayerManager.Instance.staminaValue;

    public void OnMouseOver()   //TODO：鼠標放上去會放大，同時卡牌會顯示名稱和功能
    {
        Debug.Log("Mouse is over this object.");
    }

    public void OnMouseDown()
    {
        ActionType[] actionTypes =
        {
            ActionType.DashBlock,
            ActionType.GrowingShield,
            ActionType.IronCastle,
            ActionType.Block
        };
        if (staminaValue < 1)
            return;
        if (actionTypes.Contains(actionType))
        {
            string methodName = actionType.ToString();        //呼叫ActionType名子
            MethodInfo method = Pa.GetType().GetMethod(methodName);       //勿
            if (method != null)
            {
                method.Invoke(Pa, null);
            }
            else
            {
                Debug.LogError("找不到");
            }
        }
        else
        {
            Pa.DoAction(actionType);                //將改成傳入"ActionType"
        }
        ResetCards();
    }

    public void ResetCards()
    {
        CardManager.Instance.GetComponent<GraveYard>().graveYardCard.Add(this.gameObject);
        transform.position = GameObject.Find("Draw").transform.position;
        Destroy(GetComponent<HandCards>());
    }
}

public enum ActionType
{
    Attack,
    Slash,
    Smash,
    SplitSlash,
    Spin,
    QuickStab,
    DashBlock,
    GrowingShield,
    IronCastle,
    Block
}

