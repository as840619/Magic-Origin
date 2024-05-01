using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class V_Dialog : MonoBehaviour
{
    public Text textComponent;
    public string[] lines;
    public float textSpeed;
    public bool DialogueActive = false;

    Rigidbody2D playerRb;
    private int index =0;
    void Start()
    {
        if (playerRb == null)
        {
            playerRb = GameObject.FindWithTag("Player")?.GetComponent<Rigidbody2D>();
        }
        StartDialogue();
    }

    void Update()
    {

        //檢查是否正在進行對話，如果是則不處理按鍵輸入（除非是跳過對話的特定按鍵）
        if (DialogueActive && InputSystem.GetDevice<Keyboard>().kKey.wasPressedThisFrame)//action.UI.Click.IsPressed())
        {
            NextLine();
        }
    }

public void StartDialogue()
    {
        DialogueActive = true;
        index = 0;
        playerRb.bodyType = RigidbodyType2D.Static;
        StartCoroutine(TypeLine());
        Debug.Log("StartDia");
    }
    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {

        StopAllCoroutines();
        index++;
        Debug.Log("NextLine() - Current index: " + index);
        if (index < lines.Length)
        {

            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            EndDialogue();
        }
    }
    public void EndDialogue()
    {
        
        DialogueActive = false;
        playerRb.bodyType = RigidbodyType2D.Dynamic;
        index = 0;
        gameObject.SetActive(false);
        Debug.Log("ENDDia");
    }
}
