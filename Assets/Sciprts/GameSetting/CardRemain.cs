using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardRemain : MonoBehaviour
{
    [System.Serializable]
    public struct Cards
    {
        public GameObject Cardobj;
        public int cardAmount;
    }
    public List<Cards> CardsAmount = new();
}
