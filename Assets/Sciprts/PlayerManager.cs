using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public TextMeshProUGUI staminaValueText;
    public TextMeshProUGUI staminaMaxValueText;
    public GameObject heart;
    public int nowHealth = 0;
    public int maxHealth = 3;
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
        nowHealth = maxHealth;
        UpdateHealth();
    }

    private void Update()
    {
        if (HeartCount != nowHealth)
            UpdateHealth();
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

    private int HeartCount => GetComponent<PlayerHearts>().Hearts.Count;

    public void UpdateHealth()
    {
        if (HeartCount < 0)
            return;
        if (HeartCount <= nowHealth)
        {
            for (int i = HeartCount; HeartCount < nowHealth; i++)
            {
                // Debug.Log("心呢" + nowHealth);
                GameObject PlaerHeart = Instantiate(heart, new Vector2(-900 + i * 100, -480), Quaternion.identity);
                PlaerHeart.transform.SetParent(GameObject.FindGameObjectWithTag("UUI").transform.Find("PlayerUI"), false);
                GetComponent<PlayerHearts>().Hearts.Add(PlaerHeart);
            }
        }
        else if (GetComponent<PlayerHearts>().Hearts.Count > nowHealth)
        {
            Destroy(GetComponent<PlayerHearts>().Hearts[nowHealth]);
            GetComponent<PlayerHearts>().Hearts.RemoveAt(nowHealth);
            PlayerController.Instance.invincible = true;
            StartCoroutine(ResetAtt());
        }
    }

    private IEnumerator ResetAtt()
    {
        yield return new WaitForSeconds(2F);
        PlayerController.Instance.invincible = false;
    }
}