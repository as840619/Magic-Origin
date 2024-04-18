using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    bool invincible = false;
    public void Test()
    {
        if (invincible == false)
        {
            print("上帝模式開啟");
            invincible = true;
            PlayerController.Instance.invincible = true;
            PlayerController.Instance.createrMode = true;
        }
        else
        {
            print("上帝模式關閉");
            invincible = false;
            PlayerController.Instance.invincible = false;
            PlayerController.Instance.createrMode = false;
        }
    }
}
