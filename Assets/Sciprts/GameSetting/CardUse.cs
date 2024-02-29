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
    public void OnMouseDown()
    {
        ActionType[] actionTypes =
        {
            ActionType.DashBlock,
            ActionType.GloryShield,
            ActionType.IronCastle,
            ActionType.Block
        };
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
        CardManager.Instance.GetComponent<GraveYard>().graveYardCard.Add(this.gameObject);
        gameObject.transform.position = GameObject.Find("Draw").transform.position;
        // DestroyImmediate(this.gameObject);
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
    GloryShield,
    IronCastle,
    Block
}

