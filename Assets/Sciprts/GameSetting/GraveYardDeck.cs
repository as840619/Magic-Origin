using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveYardDeck : MonoBehaviour
{
    private List<CardRemain.Cards> cards; 
    public List<GameObject> GraveYardCard = new();

    private void Start()
    {

    }

    public void AddToGrave(GameObject cardobj)
    {
        GraveYardCard.Add(cardobj);
    }
}
