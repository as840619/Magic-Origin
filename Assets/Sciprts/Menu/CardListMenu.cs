using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardListMenu : MonoBehaviour
{
    public List<GameObject> cardList = new();

    public void CatchCardList()
    {
        cardList.Clear();
        foreach (GameObject gameObject in CardManager.Instance.GetComponent<GraveYard>().CardList)
            cardList.Add(gameObject);
        foreach (GameObject gameObject in CardManager.Instance.GetComponent<CardRemain>().CardList)
            cardList.Add(gameObject);
        foreach (GameObject gameObject in CardManager.Instance.GetComponent<HandCards>().CardList)
            cardList.Add(gameObject);
        SortingList();
        ShowCards();
    }

    private void ShowCards()
    {
        for (int i = 0; i < cardList.Count; i++)
        {
            int j = i / 4;
            GameObject card = Instantiate(cardList[i], new Vector2(620 + i % 4 * (195.31F), 760 + j * -242), Quaternion.identity);
            card.name = cardList[i].name;
            card.transform.SetParent(transform.parent);
            card.AddComponent<CardListInUI>();
            Destroy(card.GetComponent<CardUse>());
        }
    }

    private void SortingList()
    {
        cardList.Sort((x, y) => x.name.CompareTo(y.name));
    }
}