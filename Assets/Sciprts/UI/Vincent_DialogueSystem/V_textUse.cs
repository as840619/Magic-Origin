using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class V_textUse : MonoBehaviour
{
    public Text textComponent; // 引用UI Text组件

    void Start()
    {
        // 检查是否有UI Text组件
        if (textComponent != null)
        {
            // 设置UI Text元素的文本内容
            textComponent.text = "这是一段显示的文字";
        }
        else
        {
            Debug.LogError("UI Text组件未指定！");
        }
    }
}
