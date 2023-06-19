using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChese : MonoBehaviour
{
    public float speed = 1;
    public float lineOfFocus = 11;
    public float lineOfCut = 5;
    public float fireRate = 0.5f;
    public GameObject bullet1;
    public GameObject firePosition;
    private float nextFire = 4f;
    private Transform _player;

    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(_player.position, transform.position);

        if (distanceFromPlayer > lineOfFocus)
        {
            StartCoroutine(Stray());
        }
        if (distanceFromPlayer <= lineOfFocus && distanceFromPlayer >= lineOfCut)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                var bullet = Instantiate(bullet1, firePosition.transform.position, firePosition.transform.rotation);
                bullet.GetComponent<Rigidbody2D>().velocity = bullet.transform.forward * 10000;
                Destroy(bullet, 1.5f);
            }
            transform.position = Vector2.MoveTowards(this.transform.position, _player.position, speed * Time.deltaTime);
        }
        else if (distanceFromPlayer <= lineOfCut)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, new(this.transform.position.x - _player.position.x, this.transform.position.y), speed * Time.deltaTime);
        }

    }
    IEnumerator Stray()
    {
        float time = Random.Range(1f, 2f);
        var temp = Random.Range(0, 2);
        if (temp == 0)
        {
            //while (Time.time > time)
            transform.position = Vector2.MoveTowards(this.transform.position, new(_player.position.x, this.transform.position.y), speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(this.transform.position, new(_player.position.x, this.transform.position.y), speed * Time.deltaTime);
            yield return new WaitForSeconds(time);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, lineOfFocus);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lineOfCut);

    }
}
