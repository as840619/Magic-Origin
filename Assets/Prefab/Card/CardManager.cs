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
            GameObject card = Instantiate(Card[i] ,new Vector2(5 + i * 55, 10), Quaternion.identity) ;
            card.GetComponent<CardUse>().pa=_pa;
            card.transform.SetParent(GameObject.FindGameObjectWithTag("UUI").transform, false);
        }
        
    }
    public int GetRaandomNum(List<int> listToRandomize)
    {
        int randomNum = Random.Range(0, listToRandomize.Count);
        print(randomNum);
        int printRandom = listToRandomize[randomNum];
        print(printRandom);
        return printRandom;
    }
    
    
}

