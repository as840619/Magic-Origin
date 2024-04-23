using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardListMenu : MonoBehaviour
{
    public List<GameObject> cardList = new();

    public void CatchCardList()
    {
        foreach (GameObject gameObject in CardManager.Instance.GetComponent<GraveYard>().graveYardCard)
            cardList.Add(gameObject);
        foreach (GameObject gameObject in CardManager.Instance.GetComponent<CardRemain>().CardsAmount)
            cardList.Add(gameObject);
        SortingList(cardList);
        /*for (int i = cardList.Count - 1; i >= 0; i--)
        {
            GameObject game = Instantiate(cardList[i], transform.localPosition, Quaternion.identity);   
            //cardList[i].transform.position = ;
            //cardList[i].transform.parent = transform.parent;
            game.transform.parent = transform.parent;
            cardList.RemoveAt(i);
            print(i);
        }*/
    }

    private void SortingList(List<GameObject> cardList)
    {
        for (int i = 1; i < cardList.Count; i++)
        {
            GameObject targetGameObject = CardManager.Instance.GetComponent<CardType>().cardType[i];
            int j = i - 1;
            while (j >= 0 && cardList[j] == targetGameObject)
            {
                cardList[j + 1] = cardList[j];
                j--;
            }
            cardList[j + 1] = targetGameObject;
        }
    }
}
