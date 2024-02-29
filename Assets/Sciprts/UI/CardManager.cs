using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
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
    public void GY2RM()
    {
        //GetComponent<CardRemain>().CardsAmount = GetComponent<GraveYard>().graveYardCard;
        foreach (GameObject card in GetComponent<GraveYard>().graveYardCard)
        {
            //card.SetActive(true);
            GetComponent<CardRemain>().CardsAmount.Add(card);
        }
        GetComponent<GraveYard>().graveYardCard.Clear();
    }
}
