using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemybulletScript : MonoBehaviour
{
    public float force;
    public Vector2 way;
    public GameObject Player;

    private float timer;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = Player.transform.position - transform.position;
        rb.velocity = way.normalized * force;

        float rot = Mathf.Atan2(-direction.y, -direction.x)*Mathf.Rad2Deg;//�l�u�ਤ��
        transform.rotation=Quaternion.Euler(0,0,rot+90);//����
    }

    // Update is called once per frame
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
            other.gameObject.GetComponent<PlayerHealth>().health -= 20; //�l�u���ˮ`bulletdamage
            Destroy (gameObject);
        }
    }
}
