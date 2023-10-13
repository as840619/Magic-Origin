using Pathfinding.Util;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    public List <GameObject> Card = new List<GameObject>();
    public List<int> CardtoDrugList;
    [SerializeField] PlayerAttack _pa;
    public void Onclick()
    {
        for (int i = 0; i < 5; i++)
        {
            int RandomIndex = UnityEngine.Random.Range(0, Card.Count-1);
            GameObject card = Instantiate(Card[RandomIndex] ,new Vector2(2 + i * 75, 10), Quaternion.identity) ;
            card.GetComponent<CardUse>().pa=_pa;
            card.transform.SetParent(GameObject.FindGameObjectWithTag("UUI").transform, false);
        }
        
    }

      
    
}

