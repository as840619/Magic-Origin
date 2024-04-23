using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    [Header("基本數據")]
    public int nowHealth = 0;
    public int maxHealth = 3;
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
        nowHealth = maxHealth;
    }

    private void Update()       //TODO 修改判斷
    {
        if (!takeDamage)
            return;
        if (heartRemain <= 0)
        {
            takeDamage = false;
            Invoke(nameof(KillPlayer), dieTime);      //TODO 更改兩項invoke使用方式
            FlashColor(flashTime);
            //KillPlayer();
        }
    }

    Rigidbody2D playerRb => GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    private int heartRemain => PlayerManager.Instance.nowHealth;

    private void FlashColor(float time)
    {
        sr.color = Color.black;
        Invoke("ResetColor", time);
    }

    private void ResetColor()
    {
        sr.color = originalColor;
    }

    private void KillPlayer()
    {
        StartCoroutine(GoingRestart());          //<-改這個就好 言下之意就是別讀秒
        Debug.Log("121212");
        GameManager.Instance.ResetObject();
    }

    //計時完後讀取Scene
    private IEnumerator GoingRestart()
    {
        //把RIGIDBODY從DYNAMIC轉成STATIC(讓死亡角色無法移動)
        Debug.Log("232323");
        PlayerController.Instance.invincible = true;
        playerRb.bodyType = RigidbodyType2D.Static;
        Debug.Log("343434");
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(3F);
    }
}
