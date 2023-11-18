using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    [Header("基本數據")]
    //public int health = 0;
    //private int maxHealth = 100;
    public int health;
    public int damage;
    public float flashTime;
    public float dieTime;
    private SpriteRenderer sr;
    private Color originalColor;
    private Animator anim;

    public void Start()
    {
        HealthBar.HealthMax = health;
        HealthBar.HealthCurrent = health;
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        anim = GetComponent<Animator>();
    }

    public void Update()
    {
        
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            health = 0;
        }
        HealthBar.HealthCurrent = health;
        if (health <= 0)
        {
            anim.SetTrigger("Die");
            Invoke("KillPlayer", dieTime);
            KillPlayer();
        }
        FlashColor(flashTime);
    }
    void FlashColor(float time)
    {
        sr.color = Color.black;
        Invoke("ResetColor", time);
    }
    void ResetColor()
    {
        sr.color = originalColor;
    }
    void KillPlayer()
    {
        GameManager.Instance.ResetObject();
    }

}
