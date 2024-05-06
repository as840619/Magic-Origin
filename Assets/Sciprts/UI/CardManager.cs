using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CardManager : MonoBehaviour
{
    [Header("座標")]
    [SerializeField] Transform cardRewardShow;
    [SerializeField] Transform cardRewardLerp;
    [SerializeField] RectTransform handPlace;
    [SerializeField] GameObject plusOne;
    [SerializeField] GameObject CardTrigger;
    [SerializeField] GameObject graveYard;
    //public string oooo = nameof(Attack);
    //public string opop = gameObject.GetComponentchilden<CardSkillDetails.Skills>().oooo;

    private static CardManager instance;
    public static CardManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.Find("CardManager").GetComponent<CardManager>();
            return instance;
        }
    }

    private void Update()
    {
        if (GetComponent<GraveYard>().graveYardCard.Count != 0)
            ShowGY();
    }

    private List<GameObject> cardType => GetComponent<CardType>().cardType;

    public void ShowHandCard()
    {
        List<GameObject> cardList = GetComponent<HandCards>().CardList;
        for (int i = 0; i < cardList.Count; i++)
        {
            GameObject cardObj = Instantiate(cardList[i], new Vector2(-380 + i * 145, -380), Quaternion.identity);
            cardObj.name = cardList[i].name;
            cardObj.transform.SetParent(GameObject.FindGameObjectWithTag("UUI").transform.Find("Hand"), false);
        }
    }

    public void GraveYard2CardRemain()
    {
        foreach (GameObject card in GetComponent<GraveYard>().CardList)
        {
            GetComponent<CardRemain>().CardList.Add(card);
        }
        GetComponent<GraveYard>().CardList.Clear();
        HideGraveYard();
    }

    public void HandCard2GraveYard(GameObject card)
    {
        GameObject temp = CardType.Find(c => c.GetComponent<CardUse>().actionType == card.GetComponent<CardUse>().actionType);
        int handCardNumber = card.GetComponent<CardUse>().HandCardNumber;
        GetComponent<GraveYard>().CardList.Add(temp);
        GetComponent<HandCards>().CardList.RemoveAll(card => card.GetComponent<CardUse>().HandCardNumber == handCardNumber);
        Destroy(card);
    }

    public void HandCards2GraveYard()
    {
        foreach (GameObject card in GetComponent<HandCards>().CardList)
        {
            GetComponent<GraveYard>().CardList.Add(card);
        }
        GetComponent<HandCards>().CardList.Clear();
        foreach (GameObject card in GameObject.FindGameObjectsWithTag("Card"))
        {
            Destroy(card);
        }
    }

    public void DropCard(Vector3 vector3)
    {
        Instantiate(CardTrigger, vector3, Quaternion.identity);
    }

    public void CardInstantiate()
    {
        graveYard.SetActive(true);
    }

    IEnumerator CardAddEvent(GameObject gameObject)
    {
        yield return new WaitForSeconds(1.5F);
        gameObject.transform.position = GameObject.Find("Draw").transform.position;
        plusOne.SetActive(true);
        yield return new WaitForSeconds(1.5F);
        plusOne.SetActive(false);
    }
}
