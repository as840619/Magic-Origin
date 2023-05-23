using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("基本數據")]
    public int health;
    public int damage;
    public float flashTime;
    public float dieTime;
    private SpriteRenderer sr;
    private Color originalColor;
    private Animator anim;

    // Start is called before the first frame update
    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (health <= 0)
        {
            health = 0;
        }
        if (health <= 0)
        {
            anim.SetTrigger("Die");
            Invoke("KillPlayer", dieTime);
        }
    }
    public void TakeDamage(int damage)
    {

        health -= damage;
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
        Destroy(gameObject);
    }

}
