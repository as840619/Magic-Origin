using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class CardUse : MonoBehaviour
{
    // public bool cardn = false;//�ǥh���ⱱ��ƭ�
    public PlayerAttack pa;
    public void OnMouseDown()
    {
        Debug.Log("���P����");
        pa.Attack();
        //cardn = true;
        DestroyImmediate(this.gameObject);//�ήɺR������
        //Debug.Log(cardn);
    }
}
