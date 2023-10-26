using Pathfinding.Util;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public List <GameObject> Card = new List<GameObject>();
    public List<int> CardtoDrugList;
    //[SerializeField] PlayerAttack _pa;

    public Button drawbutton;
    
    public void Onclick()
    {
        for (int i = 0; i < 5; i++)
        {
            int RandomIndex = UnityEngine.Random.Range(0, Card.Count-1);
            GameObject card = Instantiate(Card[RandomIndex] ,new Vector2(2 + i * 75, 10), Quaternion.identity) ;
            card.transform.SetParent(GameObject.FindGameObjectWithTag("UUI").transform, false);
        }
        drawbutton.enabled = false;//抽卡按鈕關閉
        usedd();
    }
    void usedd()//觸發計時器用
    {
        StartCoroutine(drawcooldown());
    }

    
    //計時器
   public  IEnumerator drawcooldown()
    {
        yield return new WaitForSecondsRealtime(5);//真實秒數
        drawbutton.enabled = true;
    }


}

