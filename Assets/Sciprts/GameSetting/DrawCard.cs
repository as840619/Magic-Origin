using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCard : MonoBehaviour
{
    private List<GameObject> CardsRemainList => CardManager.Instance.GetComponent<CardRemain>().CardList;

    public Button drawbutton;
    private const int MAXHANDCARD = 5;

    public void Onclick()
    {
        CardManager.Instance.HandCards2GraveYard();
        for (int i = 0; i < MAXHANDCARD; i++)
        {
            GameObject cardObj = GetRandomCard();
            cardObj.GetComponent<CardUse>().HandCardNumber = i;
            CardManager.Instance.GetComponent<HandCards>().CardList.Add(cardObj);
        }
        CardManager.Instance.ShowHandCard();
        drawbutton.enabled = false;//抽卡按鈕關閉
        UseDraw();
    }

    private GameObject GetRandomCard()
    {
        if (CardsRemainList.Count == 0)
            CardManager.Instance.GraveYard2CardRemain();
        int RandomIndex = Random.Range(0, CardsRemainList.Count);
        GameObject cardObj = CardsRemainList[RandomIndex];
        CardsRemainList.RemoveAt(RandomIndex);
        return cardObj;
    }

    private IEnumerator DrawCoolDown()   //計時器
    {
        yield return new WaitForSecondsRealtime(1/*5*/);//真實秒數
        drawbutton.enabled = true;
    }

    private void UseDraw()//觸發計時器用
    {
        StartCoroutine(DrawCoolDown());
    }
}