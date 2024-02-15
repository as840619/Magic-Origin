using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    //public List<GameObject> Card = new();
    public List<CardRemain.Cards> cards;
    public List<int> CardtoDrugList;
    //[SerializeField] PlayerAttack _pa;
    public Button drawbutton;

    /*private void Start()
    {
        cards = GetComponent<CardRemain>().CardsAmount;
    }*/
    private void Update()
    {
        
    }
    
    public void Onclick()
    {
        for (int i = 0; i < 5; i++)
        {
            int RandomIndex = GetRandomIndex();
            if ()
            {
                break;
            }
            GameObject card = Instantiate(cards[RandomIndex].Cardobj, new Vector2(2 + i * 75, 10), Quaternion.identity);
            card.transform.SetParent(GameObject.FindGameObjectWithTag("UUI").transform, false);
            
        }
        drawbutton.enabled = false;//抽卡按鈕關閉
        UseDraw();
    }

    public IEnumerator DrawCoolDown()   //計時器
    {
        yield return new WaitForSecondsRealtime(5);//真實秒數
        drawbutton.enabled = true;
    }

    private int GetRandomIndex()
    {
        return Random.Range(0, cards.Count - 1);
    }


    private void UseDraw()//觸發計時器用
    {
        StartCoroutine(DrawCoolDown());
    }
}

