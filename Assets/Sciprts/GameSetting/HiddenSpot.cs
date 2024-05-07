using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenSpot : MonoBehaviour
{
    [Header("基本")]
    [SerializeField] new Renderer renderer;
    //[SerializeField] bool touchedLine = false;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    public void SortingLayer()
    {
        renderer.sortingOrder = 1;
    }

    public void LeaveSpot()
    {
        renderer.sortingOrder = 10;
    }
}
