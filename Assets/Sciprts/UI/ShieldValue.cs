using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldValue : MonoBehaviour
{
    public int shieldValue;  //當前護盾量
    public TextMeshProUGUI shieldText;
        
    void Update()
    {
        if (shieldValue >= 0)
            shieldText.text = shieldValue.ToString();
        if (shieldValue == 0)
            shieldText.text = "";
    }
}
