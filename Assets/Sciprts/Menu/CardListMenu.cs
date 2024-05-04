using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardListMenu : MonoBehaviour
{
    public List<GameObject> cardList = new();

    public void CatchCardList()
    {
        cardList.RemoveRange(0,cardList.Count);
        foreach (GameObject gameObject in CardManager.Instance.GetComponent<GraveYard>().graveYardCard)
            cardList.Add(gameObject);
        foreach (GameObject gameObject in CardManager.Instance.GetComponent<CardRemain>().CardsAmount)
            cardList.Add(gameObject);
        SortingList(cardList);
        ShowCards();
    }

    private void ShowCards()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            GameObject card = Instantiate(cardList[i], new Vector2(0 + i * 145, 380), Quaternion.identity);
            card.name = cardList[i].name;
            card.transform.parent = transform.parent;
            card.AddComponent<CardListInUI>();
            Destroy(card.GetComponent<CardUse>());
        }
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
