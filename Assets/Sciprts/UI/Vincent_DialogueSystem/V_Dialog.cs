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
    [SerializeField] private int index = 0;

    private void Update()
    {
        //檢查是否正在進行對話，如果是則不處理按鍵輸入（除非是跳過對話的特定按鍵）
        if (DialogueActive && InputSystem.GetDevice<Mouse>().leftButton.wasPressedThisFrame)       //action.UI.Click.IsPressed())
            NextLine();
    }

    public void StartDialogue()
    {
        // Debug.Log("StartDia");
        DialogueActive = true;
        PlayerController.Instance.canMove = false;
        index = 0;
        StartCoroutine(TypeLine());
    }

    public void EndDialogue()
    {
        DialogueActive = false;
        PlayerController.Instance.canMove = true;
        gameObject.SetActive(false);
        // Debug.Log("ENDDia");
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    private void NextLine()
    {
        StopAllCoroutines();
        // Debug.Log("NextLine() - Current index: " + index);
        if (++index >= lines.Length)
        {
            EndDialogue();
            return;
        }
        textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }
}
