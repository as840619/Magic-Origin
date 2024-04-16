using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public TextMeshProUGUI staminaValueText;
    public TextMeshProUGUI staminaMaxValueText;
    public int shieldValue;
    public bool weakness;
    public float weaknessTime;
    public int staminaValue = 6;
    public int staminaMaxValue = 6;
    float tempTime;

    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            return instance;
        }
    }
    private void Start()
    {
        staminaValueText.text = staminaValue.ToString();
        staminaMaxValueText.text = staminaMaxValue.ToString();

    }

    private void Update()
    {
        staminaValueText.text = staminaValue.ToString();
        staminaMaxValueText.text = staminaMaxValue.ToString();
        if (staminaValue >= staminaMaxValue)
            return;
        if (weakness)
        {
            weaknessTime += Time.deltaTime;
            tempTime += Time.deltaTime / 4;
            if (weaknessTime >= 0.5f)
                weakness = false;
        }
        else
            tempTime += Time.deltaTime;
        if (tempTime >= 1)
        {
            staminaValue += ((int)tempTime);
            tempTime = 0;
        }
    }
}
