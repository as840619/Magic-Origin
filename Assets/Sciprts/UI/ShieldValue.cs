using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShieldValue : MonoBehaviour
{
    public TextMeshProUGUI shieldText;
    
    private int shieldInt => PlayerManager.Instance.shieldValue;
    private void Start()
    {
        shieldText.fontSize = 0.1f;
    }
    void Update()
    {
        if (shieldInt >= 0)
            shieldText.text = shieldInt.ToString();
        if (shieldInt == 0)
            shieldText.text = "";
    }
}
