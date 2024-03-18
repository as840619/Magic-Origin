using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("基本數據")]
    public int damage;
    public float time;
    private int shieldInt;
    private new PolygonCollider2D collider;

    private void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    /*int Shield
    {
        get
        {
            int shieldValue = GameObject.FindWithTag("Player").GetComponentInChildren<ShieldValue>().shieldValue;
            return shieldValue;
        }
        set
        {
        }           
    }*/

    //ShieldValue ShieldValue => GameObject.Find("Shield").GetComponent<ShieldValue>();
    Animator Animation => PlayerController.Instance.GetComponent<Animator>();

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
        PlayerManager.Instance.shieldValue += 1;
        StartCoroutine(DisableHitBox());
    }
    public void GloryShield()
    {
        print("GloryShield");
        collider.enabled = true;
        Animation.SetTrigger("GloryShield");
        PlayerManager.Instance.shieldValue += 2;
        StartCoroutine(DisableHitBox());
    }
    public void IronCastle()
    {
        print("IronCastle");
        collider.enabled = true;
        Animation.SetTrigger("IronCastle");
        PlayerManager.Instance.shieldValue += 3;
        StartCoroutine(DisableHitBox());
    }
    public void Block()
    {
        print("Block");
        collider.enabled = true;
        Animation.SetTrigger("Block");
        PlayerManager.Instance.shieldValue += 4;
        StartCoroutine(DisableHitBox());
    }

    public void PP()
    {
        if (collider != null)
        {
            collider.points = new Vector2[] {  };
        }
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
