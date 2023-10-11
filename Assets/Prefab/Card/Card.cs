using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Card : MonoBehaviour
{
    public enum CardClass { Attack, Block, Special }
    [CreateAssetMenu(fileName = "New Card", menuName = "Create CardAsset")]
    public class CardAsset : ScriptableObject
    {
        [Header("基本功能")]
        [Tooltip("ID")]
        public  int CardId=0;
        [Tooltip("NAME")]
        public string CardName="";
        [Tooltip("描述")]
        public string CardDiscription="";
    }


}
