using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawCard : MonoBehaviour
{
    //public List<GameObject> Card = new();
    private List<GameObject> CardsAmount => CardManager.Instance.GetComponent<CardRemain>().CardsAmount;

    public Button drawbutton;
    private int maxHandCard = 5;

    public void Onclick()
    {
        for (int i = 0; i < maxHandCard; i++)
        {
            GameObject cardObj = GetRandomCard();
            GameObject card = Instantiate(cardObj, new Vector2(-100 + i * 120, -400), Quaternion.identity);
            card.name = cardObj.name;
            card.transform.SetParent(GameObject.FindGameObjectWithTag("UUI").transform.Find("Hand"), false);
        }
        drawbutton.enabled = false;//抽卡按鈕關閉
        UseDraw();
    }

    private GameObject GetRandomCard()
    {
        if (CardsAmount.Count == 0)
        {
            CardManager.Instance.GY2RM();
        }

        int RandomIndex = Random.Range(0, CardsAmount.Count - 1);
        GameObject cardObj = CardsAmount[RandomIndex];
        CardsAmount.RemoveAt(RandomIndex);
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

