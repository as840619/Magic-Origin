using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class CardUse : MonoBehaviour
{
    // public bool cardn = false;//
    public PlayerAttack pa;
    public void OnMouseDown()
    {
        Debug.Log("攻擊");
        pa.Attack();
        //cardn = true;
        DestroyImmediate(this.gameObject);
    }
}
