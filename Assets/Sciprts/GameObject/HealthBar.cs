using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text HealthText;
    public static int HealthCurrent;//當前血量值
    public static int HealthMax;//最大血量值
    private Image healthBar;
    public GameObject target;
    public float offsetY = 40f;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 targetP = Camera.main.WorldToScreenPoint(target.transform.position);
        healthBar.GetComponent<RectTransform>().position = targetP + Vector2.up * offsetY;

        healthBar.fillAmount = (float)HealthCurrent / (float)HealthMax;
        HealthText.text = HealthCurrent.ToString() + "/" + HealthMax.ToString();
    }
}
