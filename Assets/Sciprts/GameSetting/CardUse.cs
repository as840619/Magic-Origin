using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class CardUse : MonoBehaviour
{
    // public bool cardn = false;//�ǥh���ⱱ��ƭ� wrong unicode
    public PlayerAttack pa;
    public void OnMouseDown()
    {
        Debug.Log("攻擊");
        if (this.gameObject.name == "CardA1")
            pa.Attack();
        if (this.gameObject.name == "CardA1(Clone)")
            pa.Attack();

        if (this.gameObject.name == "CardA2")
            pa.Slash();
        if (this.gameObject.name == "CardA2(Clone)")
            pa.Slash();

        if (this.gameObject.name == "CardA3")
            pa.Smash();
        if (this.gameObject.name == "CardA3(Clone)")
            pa.Smash();

        if (this.gameObject.name == "CardA4")
            pa.SplitSlash();
        if (this.gameObject.name == "CardA4(Clone)")
            pa.SplitSlash();

        if (this.gameObject.name == "CardA5")
            pa.Spin();
        if (this.gameObject.name == "CardA5(Clone)")
            pa.Spin();

        if (this.gameObject.name == "CardA6")
            pa.QuickStab();
        if (this.gameObject.name == "CardA6(Clone)")
            pa.QuickStab();

        if (this.gameObject.name == "CardD1")
            pa.DashBlock();
        if (this.gameObject.name == "CardD1(Clone)")
            pa.DashBlock();

        if (this.gameObject.name == "CardD2")
            pa.GloryShield();
        if (this.gameObject.name == "CardD2(Clone)")
            pa.GloryShield();

        if (this.gameObject.name == "CardD3")
            pa.IronCastle();
        if (this.gameObject.name == "CardD3(Clone)")
            pa.IronCastle();

        if (this.gameObject.name == "CardD4")
            pa.Block();
        if (this.gameObject.name == "CardD4(Clone)")
            pa.Block();


        //cardn = true;
        DestroyImmediate(this.gameObject);//�ήɺR������  wrong unicode
        //Debug.Log(cardn);
    }
}

