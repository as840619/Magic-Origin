using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [Header("基本數據")]
    public int health = 0;
    private int maxHealth = 100;
    public int damage;
    public float flashTime;
    public float dieTime;
    private SpriteRenderer sr;
    private Color originalColor;
    private Animator anim;

    private Rigidbody2D rb;

    public void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        anim = GetComponent<Animator>();
        health = maxHealth;

        rb = GetComponent<Rigidbody2D>();
    }

    public void Update()
    {
        if (health <= 0)
        {
            health = 0;
        }
        if (health <= 0)
        {

            //Invoke("KillPlayer", dieTime);
            KillPlayer();
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

        //把RIGIDBODY從DYNAMIC轉成STATIC(讓死亡角色無法移動)
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        GameManager.Instance.ResetObject();
        //StartCoroutine(SecondToScene());           <-改這個就好 言下之意就是別讀秒
    }

    //計時完後讀取Scene
    private IEnumerator SecondToScene()
    {
        yield return new WaitForSeconds(3);
        //Test();
    }

    void Test()
    {
    }

}
