using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("基本數據")]
    public float time;
    private int shieldInt;
    private new PolygonCollider2D collider;

    private void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    Animator Animation => PlayerController.Instance.GetComponent<Animator>();

    ////////////////////////////////////設置collider用區域//////////////////////////////////
    private void SetColliderShapeAction1()
    {
        if (collider != null)
        {
            collider.points = new Vector2[]
            {
                //調整poin裡數據(直接看著調)
                    new Vector2(0.1f,-0.01f), // 左下角
                    new Vector2(0.23f,-0.01f),  // 右下角
                    new Vector2(0.23f, 0.1f),   // 右上角
                    new Vector2(0.1f, 0.1f)   // 左上角
            };
        }
    }
    private void SetColliderShapeAction2()
    {
        if (collider != null)
        {
            collider.points = new Vector2[]
            {
                    new Vector2(0.36f, -0.04f), // 左下角
                    new Vector2(0.13f, -0.03f),  // 右下角
                    new Vector2(0.11f, -0.08f),   // 右上角
                    new Vector2(0.35f,-0.18f)   // 左上角
            };
        }
    }
    private void SetColliderShapeAction3()
    {
        if (collider != null)
        {
            collider.points = new Vector2[]
            {
                //調整poin裡數據(直接看著調)
                    new Vector2(-0.02f, -0.22f), // 左下角
                    new Vector2(0.35f, -0.23f),  // 右下角
                    new Vector2(0.22f, -0.03f),   // 右上角
                    new Vector2(0.13f, -0.03f)   // 左上角
            };
        }
    }
    private void SetColliderShapeAction4()
    {
        if (collider != null)
        {
            collider.points = new Vector2[]
            {
                //調整poin裡數據(直接看著調)
                    new Vector2(-0.36f,-0.05f), // 左下角
                    new Vector2(0.36f, -0.05f),  // 右下角
                    new Vector2(0.36f, 0.05f),   // 右上角
                    new Vector2(-0.36f, 0.05f)   // 左上角
            };
        }
    }
    private void SetColliderShapeAction5()
    {
        if (collider != null)
        {
            collider.points = new Vector2[]
            {
                //調整poin裡數據(直接看著調)
                    new Vector2(-0.15f, -0.2f), // 左下角
                    new Vector2(0.15f, -0.2f),  // 右下角
                    new Vector2(0.3f, 0.25f),   // 右上角
                    new Vector2(-0.3f, 0.25f)   // 左上角
            };
        }
    }
    private void SetColliderShapeAction6()
    {
        if (collider != null)
        {
            collider.points = new Vector2[]
            {
                //調整poin裡數據(直接看著調)
                    new Vector2(0.1f, -0.1f), // 左下角
                    new Vector2(0.2f, -0.05f),  // 右下角
                    new Vector2(0.2f, 0.1f),   // 右上角
                    new Vector2(0.1f, 0.1f)   // 左上角
            };
        }
    }
    private void SetColliderShapeAction7()
    {
        if (collider != null)
        {
            collider.points = new Vector2[]
            {
                //調整poin裡數據(直接看著調)
                    new Vector2(0.1f, -0.18f), // 左下角
                    new Vector2(0.26f, -0.18f),  // 右下角
                    new Vector2(0.26f, 0.1f),   // 右上角
                    new Vector2(0.1f, 0.1f)   // 左上角
            };
        }
    }
    private void SetColliderShapeAction8()
    {
        if (collider != null)
        {
            collider.points = new Vector2[]
            {
                //調整poin裡數據(直接看著調)
                    new Vector2(0f, -0.23f), // 左下角
                    new Vector2(0.28f, -0.23f),  // 右下角
                    new Vector2(0.28f, 0.2f),   // 右上角
                    new Vector2(0f, 0.2f)   // 左上角
            };
        }
    }
    private void SetColliderShapeAction9()
    {
        if (collider != null)
        {
            collider.points = new Vector2[]
            {
                //調整poin裡數據(直接看著調)
                    new Vector2(-0.5f, -0.5f), // 左下角
                    new Vector2(0.5f, -0.5f),  // 右下角
                    new Vector2(0.5f, 0.5f),   // 右上角
                    new Vector2(-0.5f, 0.5f)   // 左上角
            };
        }
    }
    private void SetColliderShapeAction10()
    {
        if (collider != null)
        {
            collider.points = new Vector2[]
            {
                //調整poin裡數據(直接看著調)
                    new Vector2(-0.5f, -0.5f), // 左下角
                    new Vector2(0.5f, -0.5f),  // 右下角
                    new Vector2(0.5f, 0.5f),   // 右上角
                    new Vector2(-0.5f, 0.5f)   // 左上角
            };
        }
    }
    private void SetRendererAction10()
    {
        //GameObject.Find("ShieldRing").SetActive(true);
    }


    public void PerformAction1()
    {
        Debug.Log("動作1開始");
        SetColliderShapeAction1();
        Debug.Log("動作1結束");
    }
    public void PerformAction2()
    {
        Debug.Log("動作2開始");
        SetColliderShapeAction2();
        Debug.Log("動作2結束");
    }
    public void PerformAction3()
    {
        Debug.Log("動作3開始");
        SetColliderShapeAction3();
        Debug.Log("動作3結束");
    }
    public void PerformAction4()
    {
        Debug.Log("動作4開始");
        SetColliderShapeAction4();
        Debug.Log("動作4結束");
    }
    public void PerformAction5()
    {
        Debug.Log("動作5開始");
        SetColliderShapeAction5();
        Debug.Log("動作5結束");
    }
    public void PerformAction6()
    {
        Debug.Log("動作6開始");
        SetColliderShapeAction6();
        Debug.Log("動作6結束");
    }
    public void PerformAction7()
    {
        Debug.Log("動作7開始");
        SetColliderShapeAction7();
        Debug.Log("動作7結束");
    }
    public void PerformAction8()
    {
        Debug.Log("動作8開始");
        SetColliderShapeAction8();
        Debug.Log("動作8結束");
    }
    public void PerformAction9()
    {
        Debug.Log("動作9開始");
        SetColliderShapeAction9();
        Debug.Log("動作9結束");
    }
    public void PerformAction10()
    {
        Debug.Log("動作10開始");
        SetColliderShapeAction10();
        Debug.Log("動作10結束");
    }
    ////////////////////////////////////設置collider用區域//////////////////////////////////

    //DoAction
    public void DoAction(ActionType actionType)
    {
        print(actionType);
        PlayerManager.Instance.staminaValue -= 1;

        switch (actionType)//辨識動作變更collider
        {
            case ActionType.Attack:
                //CardManager.Instance.GetComponentInChildren<CardSkillDetails>()..name[1];
                PerformAction1();
                break;
            case ActionType.Slash:
                PerformAction2();
                break;
            case ActionType.Smash:
                PerformAction3();
                break;
            case ActionType.SplitSlash:
                PerformAction4();
                break;
            case ActionType.Spin:
                PerformAction5();
                break;
            case ActionType.QuickStab:
                PerformAction6();
                break;
        }

        collider.enabled = true;
        Animation.SetTrigger(actionType.ToString());
        StartCoroutine(DisableHitBox());
    }

    public void DashBlock()
    {
        print("DashBlock");
        PlayerManager.Instance.staminaValue -= 0;
        PerformAction7();
        collider.enabled = true;
        //PlayerController.Instance.Dash();
        Animation.SetTrigger("DashBlock");
        PlayerManager.Instance.shieldValue += 2;
        StartCoroutine(DisableHitBox());
    }

    public void GrowingShield()
    {
        print("GrowingShield");
        PlayerManager.Instance.staminaValue -= 1;
        PerformAction8();
        collider.enabled = true;
        Animation.SetTrigger("GrowingShield");
        PlayerManager.Instance.shieldValue += 1;
        StartCoroutine(DisableHitBox());
        StartCoroutine(GrowingShieldValue());
    }

    public void IronCastle()
    {
        print("IronCastle");
        PlayerManager.Instance.staminaValue -= 2;
        collider.enabled = true;
        Animation.SetTrigger("IronCastle");
        if (PlayerController.Instance.createrMode == false)
            StartCoroutine(InvincibleTime());
        SetRendererAction10();
        StartCoroutine(DisableHitBox());
    }

    public void Block()
    {
        print("Block");
        PlayerManager.Instance.staminaValue -= 1;
        collider.enabled = true;
        Animation.SetTrigger("Block");
        PlayerManager.Instance.shieldValue += 4;
        StartCoroutine(DisableHitBox());
    }

    IEnumerator GrowingShieldValue()
    {
        int i = 1;
        while (i == 12)
        {
            yield return new WaitForSeconds(1F);
            PlayerManager.Instance.shieldValue += i * 2;
        }
    }

    IEnumerator DisableHitBox()
    {
        yield return new WaitForSeconds(time);
        collider.enabled = false;
    }

    IEnumerator InvincibleTime()
    {
        PlayerController.Instance.invincible = true;
        yield return new WaitForSeconds(5F);
        PlayerController.Instance.invincible = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(10);
                Debug.Log("有傷害");
            }
            else
            {
                Debug.LogWarning("可能沒事吧");
            }
        }
    }
}