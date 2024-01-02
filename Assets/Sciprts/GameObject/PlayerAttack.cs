using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("基本數據")]
    public int damage;
    public float time;

    private new PolygonCollider2D collider;

    private void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    private Animator Animation => PlayerController.Instance.GetComponent<Animator>();
    //private int shield => GameObject.Find("ShieldRemain").AddComponent<>()

    public void DoAction(ActionType actionType)
    {
        print(actionType);
        collider.enabled = true;
        Animation.SetTrigger(actionType.ToString());
        StartCoroutine(DisableHitBox());
    }
    public void DashBlock()
    {
        print("DashBlock");
        collider.enabled = true;
        
        //PlayerController.Instance.Dash();
        Animation.SetTrigger("DashBlock");
        StartCoroutine(DisableHitBox());
    }
    public void GloryShield()
    {
        print("GloryShield");
        collider.enabled = true;
        Animation.SetTrigger("GloryShield");
        StartCoroutine(DisableHitBox());
    }
    public void IronCastle()
    {
        print("IronCastle");
        collider.enabled = true;
        Animation.SetTrigger("IronCastle");
        StartCoroutine(DisableHitBox());
    }
    public void Block()
    {
        print("Block");
        collider.enabled = true;
        Animation.SetTrigger("Block");
        StartCoroutine(DisableHitBox());
    }


    IEnumerator DisableHitBox()
    {
        yield return new WaitForSeconds(time);
        collider.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }

}
