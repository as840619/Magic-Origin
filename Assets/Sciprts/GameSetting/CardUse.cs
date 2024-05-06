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
    public ActionType actionType;
    public int HandCardNumber = -1;

    private PlayerAttack Pa => PlayerController.Instance.GetComponentInChildren<PlayerAttack>();
    private int StaminaValue => PlayerManager.Instance.staminaValue;

    //TODO：鼠標放上去會放大，同時卡牌會顯示名稱和功能 OnMouseOver()

    public void OnMouseDown()
    {
        ActionType[] actionTypes =
        {
            ActionType.DashBlock,
            ActionType.GrowingShield,
            ActionType.IronCastle,
            ActionType.Block
        };
        if (StaminaValue < 1)
            return;
        if (actionTypes.Contains(actionType))
        {
            string methodName = actionType.ToString();        //呼叫ActionType名子
            MethodInfo method = Pa.GetType().GetMethod(methodName);
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
        CardManager.Instance.HandCard2GraveYard(gameObject);
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