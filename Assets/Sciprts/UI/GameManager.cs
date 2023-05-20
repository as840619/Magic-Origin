using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    [Header("基本數據")]
    public static int enemyInfectorFarHP;
    public static int enemyInfectorNearHP;
    public static int enemyInfectorBossHP;
    public static int enemyHP;
    [Header("介面控制")]
    [SerializeField] Text _enemyInfectorFarHPText;
    [SerializeField] Text _enemyInfectorNearHPText;
    [SerializeField] Text _enemyInfectorBossHPText;

}
