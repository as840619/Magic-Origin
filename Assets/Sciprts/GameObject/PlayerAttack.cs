using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("基本數據")]
    public int damage;
    public float time;

    private new PolygonCollider2D collider;

    void Start()
    {
        collider = GetComponent<PolygonCollider2D>();
    }

    Animator anim => PlayerController.Instance.GetComponent<Animator>();

    public void Attack()
    {
        print("attack");
        collider.enabled = true;
        anim.SetTrigger("Attack");
        StartCoroutine(disableHitBox());
    }
    public void Slash()
    {
        print("Slash");
        collider.enabled = true;
        anim.SetTrigger("slash");
        StartCoroutine(disableHitBox());
    }
    public void Smash()
    {
        print("Smash");
        collider.enabled = true;
        anim.SetTrigger("smash");
        StartCoroutine(disableHitBox());
    }
    public void SplitSlash()
    {
        print("SplitSlash");
        collider.enabled = true;
        anim.SetTrigger("split_slash");
        StartCoroutine(disableHitBox());
    }
    public void QuickStab()
    {
        print("QuickStab");
        collider.enabled = true;
        anim.SetTrigger("quick_stab");
        StartCoroutine(disableHitBox());
    }
    public void Spin()
    {
        print("Spin");
        collider.enabled = true;
        anim.SetTrigger("spin");
        StartCoroutine(disableHitBox());
    }
    public void Block()
    {
        print("Block");
        collider.enabled = true;
        anim.SetTrigger("block");
        StartCoroutine(disableHitBox());
    }
    public void DashBlock()
    {
        print("DashBlock");
        collider.enabled = true;
        anim.SetTrigger("dash_block");
        StartCoroutine(disableHitBox());
    }
    public void IronCastle()
    {
        print("IronCastle");
        collider.enabled = true;
        anim.SetTrigger("iron_castle");
        StartCoroutine(disableHitBox());
    }
    public void GloryShield()
    {
        print("GloryShield");
        collider.enabled = true;
        anim.SetTrigger("glory_shield");
        StartCoroutine(disableHitBox());
    }

    IEnumerator disableHitBox()
    {
        yield return new WaitForSeconds(time);
        collider.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Destroy(gameObject);
            print("hit");
            other.GetComponent<Enemy>().TakeDamage(damage);
        }
    }
}
