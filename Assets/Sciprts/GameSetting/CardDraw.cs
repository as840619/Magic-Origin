using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDraw : MonoBehaviour
{
    //int rank = 0;
    public GameObject CardS1;
    public GameObject CardS2;
    [SerializeField] PlayerAttack _pa;
    public void OnClick()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject card = Instantiate(CardS1, new Vector2(5 + i * 55, 10), Quaternion.identity);
            card.GetComponent<CardUse>().pa = _pa;
            card.transform.SetParent(GameObject.FindGameObjectWithTag("UUI").transform, false);
        }
    }
}
