using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemybulletScript : MonoBehaviour
{
    public bool lerping = false;
    public float force;
    public float reCallTime;
    public Vector2 way;

    private float timer;
    private Rigidbody2D rb;
    private GameObject Player;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");
        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = way.normalized * force;
        float rot = Mathf.Atan2(-way.y, -way.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().health -= 20; //bulletdamage
            Destroy(gameObject);
        }
    }
}
