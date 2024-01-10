using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [Header("基本數據")]
    public int health;
    public float flashTime;
    public float dieTime;
    public bool takeDamage;
    private SpriteRenderer sr;
    private Color originalColor;
    private Animator anim;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        originalColor = sr.color;
        anim = GetComponent<Animator>();
    }

    private void Update()       //TODO 修改判斷
    {
        if (!takeDamage)
            return;
        if (health <= 0)
        {
            takeDamage = false;
            health = 0;
            anim.SetTrigger("Die");
            Invoke("KillPlayer", dieTime);      //TODO 更改兩項invoke使用方式
            FlashColor(flashTime);
            KillPlayer();
        }
    }

    Rigidbody2D playerRb => GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();

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
        playerRb.bodyType = RigidbodyType2D.Static;
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

}
