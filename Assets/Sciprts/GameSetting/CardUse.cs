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
            MethodInfo method = Pa.GetType().GetMethod(actionType.ToString());
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

public enum ActionType  //TIPS：enum可以代替string的功能，是一個基礎類型，原理上，自動幫我們把字串作編號的字典的概念，
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