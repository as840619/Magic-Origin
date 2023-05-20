using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiPlayerHand : MonoBehaviour
{
    int Count { get; set; }

    [SerializeField]
    [Tooltip("Prefab of the Card C#")]
    GameObject cardPrefabCs;

    [SerializeField]
    [Tooltip("World point where the deck is positioned")]
    Transform deckPosition;

    [SerializeField]
    [Tooltip("Game view transform")]
    Transform gameView;

    //void Awake() => PlayerHand = transform.parent.GetComponentInChildren<IUiPlayerHand>();

    IEnumerator Start()
    {
        //starting cards
        for (var i = 0; i < 5; i++)
        {
            yield return new WaitForSeconds(0.2f);
            DrawCard();
        }
    }
    public void DrawCard()
    {
        //TODO: Consider replace Instantiate by an Object Pool Pattern
        var cardGo = Instantiate(cardPrefabCs, gameView);
        cardGo.name = "Card_" + Count;
        //var card = cardGo.GetComponent<IUiCard>();
        //card.transform.position = deckPosition.position;
        Count++;
        //PlayerHand.AddCard(card);
    }
}
