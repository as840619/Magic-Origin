using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;

public class CardUse : MonoBehaviour
{
    // public bool cardn = false;
    [SerializeField] ActionType actionType;
    PlayerAttack pa => PlayerController.Instance.GetComponentInChildren<PlayerAttack>();
    public void OnMouseDown()
    {
        Debug.Log("攻擊");
        //呼叫ActionType名子
        string methodName = actionType.ToString();
        MethodInfo method = pa.GetType().GetMethod(methodName);
        if (method != null)
        {
            method.Invoke(pa, null);
        }
        else
        {
            Debug.LogError("找不到");
        }
        //cardn = true;
        DestroyImmediate(this.gameObject);
        //Debug.Log(cardn);
    }

}
public enum ActionType
{
    Attack, Slash, Smash, SplitSlash, Spin, QuickStab, DashBlock, GloryShield, IronCastle, Block
}
