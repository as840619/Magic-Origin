using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardListMenu : MonoBehaviour
{
    public List<GameObject> cardList = new();

    public void CatchCardList()
    {
        cardList.AddRange(GetComponent<GraveYard>().graveYardCard);
        cardList.AddRange(GetComponent<CardRemain>().CardsAmount);
    }

    private void SortingList(List<GameObject> cardList)
    {
        for (int i = 1; i < cardList.Count; i++)
        {
            GameObject targetGameObject = GetComponent<CardType>().cardType[i];
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
