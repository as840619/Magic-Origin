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

    public void CardInstantiate()
    {
        int index = Random.Range(0, 9);
        //GameObject gameObject = Instantiate(cardType[index], rectPosition.anchoredPosition, Quaternion.identity);
        GameObject gameObject = Instantiate(cardType[index], cardRewardShow.position, Quaternion.identity);
        gameObject.name = cardType[index].name;
        gameObject.transform.parent = handPlace;
        AddCardRemain(gameObject);
        StartCoroutine(CardAddEvent(gameObject));
    }

    public void DropCard(Vector3 vector3)
    {
        Instantiate(CardTrigger, vector3, Quaternion.identity);
    }

    public void AddCardRemain(GameObject gameObject)
    {
        GetComponent<CardRemain>().CardsAmount.Add(gameObject);
    }

    private void HideGY()
    {
        graveYard.SetActive(false);
    }

    private void ShowGY()
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
