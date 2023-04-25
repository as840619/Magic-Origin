using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [Header("基本數據")]
    public int damage;
    public float time;

    private Animator anim;
    private new PolygonCollider2D collider;

    void Start()
    {
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        collider = GetComponent<PolygonCollider2D>();
    }

    public void Attack()
    {
        print("attack");
        collider.enabled = true;

        anim.SetTrigger("Attack");
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
