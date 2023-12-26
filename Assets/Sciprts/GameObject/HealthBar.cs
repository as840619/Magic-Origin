using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public  int HealthCurrent;//當前血量
    public  int HealthMax;//最大血量
    SpriteRenderer spr;
    // Start is called before the first frame update
    void Start()
    {
        spr= GetComponent<SpriteRenderer>();
        HealthMax = transform.GetComponentInParent<PlayerHealth>().health;
    }

    // Update is called once per frame
    void Update()
    {
        HealthCurrent = transform.GetComponentInParent<PlayerHealth>().health;
        float p = Mathf.Max(0, (float)HealthCurrent / HealthMax);
        spr.size = new Vector2(p,1);
    }
}
