using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HealthBar : MonoBehaviour
{
    public int HealthCurrent;  //當前血量
    public int HealthMax;  //最大血量
    private SpriteRenderer spr;

    void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        HealthMax = transform.GetComponentInParent<PlayerHealth>().health;
    }

    void Update()
    {
        HealthCurrent = transform.GetComponentInParent<PlayerHealth>().health;
        float p = Mathf.Max(0, (float)HealthCurrent / HealthMax);
        spr.size = new Vector2(p, 1);
    }
}
