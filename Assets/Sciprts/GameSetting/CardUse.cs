using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class CardUse : MonoBehaviour
{
    // public bool cardn = false;//�ǥh���ⱱ��ƭ� wrong unicode
    PlayerAttack pa => PlayerController.Instance.GetComponentInChildren<PlayerAttack>();
    public void OnMouseDown()
    {
        Debug.Log("攻擊");
        if (this.gameObject.name == "CardA1")
            pa.Attack();
        if (this.gameObject.name == "CardA2")
            pa.Slash();
        if (this.gameObject.name == "CardA3")
            pa.Smash();
        if (this.gameObject.name == "CardA4")
            pa.SplitSlash();
        if (this.gameObject.name == "CardA5")
            pa.Spin();
        if (this.gameObject.name == "CardA6")
            pa.QuickStab();
        if (this.gameObject.name == "CardD1")
            pa.DashBlock();
        if (this.gameObject.name == "CardD2")
            pa.GloryShield();
        if (this.gameObject.name == "CardD3")
            pa.IronCastle();
        if (this.gameObject.name == "CardD4")
            pa.Block();



        //cardn = true;
        DestroyImmediate(this.gameObject);//�ήɺR������  wrong unicode
        //Debug.Log(cardn);
    }

}

