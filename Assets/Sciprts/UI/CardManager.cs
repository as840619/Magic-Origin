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
    [SerializeField] GameObject CardDroped;

    public List<string> skillAttack = new();
    public List<string> skillSlash = new();
    public List<string> skillSmash = new();
    public List<string> skillSplitSlash = new();
    public List<string> skillSpin = new();
    public List<string> skillQuickStab = new();
    public List<string> skillDashBlock = new();
    public List<string> skillGloryShield = new();
    public List<string> skillIronCastle = new();
    public List<string> skillBlock = new();

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

    public void DropCard(Vector2 position)
    {
        GameObject gameObject = Instantiate(CardDroped, position, Quaternion.identity);
    }

    public void AddCardRemain()
    {
        GetComponent<CardRemain>().CardsAmount.Add(cardType[Random.Range(0, 9)]);
    }

    private List<GameObject> cardType => GetComponent<CardType>().cardType;
}
