using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class CardUse : MonoBehaviour
{
    // public bool cardn = false;//傳去角色控制的數值
    public PlayerAttack pa;
    public void OnMouseDown()
    {
        Debug.Log("有感應到");
        pa.Attack();
        //cardn = true;
        DestroyImmediate(this.gameObject);//及時摧毀物件
        //Debug.Log(cardn);
    }
}
