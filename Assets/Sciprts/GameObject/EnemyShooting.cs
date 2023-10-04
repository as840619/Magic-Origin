using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private Animator anim;
    private float timer;
    private GameObject Player;

    void Start()
    {
        anim = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, Player.transform.position);
        Debug.Log(distance);

        if (distance < 5)   //Zombie Shooting Range setup
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                anim.SetTrigger("Fire");
                Shoot();
            }
        }
        if (distance >= 7.5f)   //Zombie Shooting Range setup
        {
            timer += Time.deltaTime;
            if (timer > 2)
            {
                timer = 0;
                anim.SetTrigger("Fire");
                TripperTake();
            }
        }
    }
    void Shoot()        //1 to 1
    {
        Vector2 direction = Player.transform.position - transform.position;
        GameObject bulletOTO = Instantiate(bullet, bulletPos.position, Quaternion.identity);
        bulletOTO.GetComponent<EnemybulletScript>().way = direction;
    }

    void TripperTake()      //3 to 1
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        for (int n = -1; n <= 1; n++)
        {
            Vector3 newPostion = Calculation(n);
            GameObject bulletTTO = Instantiate(bullet, bulletPos.position + newPostion, Quaternion.identity);
            Vector2 direction = Player.transform.position - bulletTTO.transform.position;
            bulletTTO.GetComponent<EnemybulletScript>().way = direction;
        }
    }
    Vector3 Calculation(int i)
    {
        Vector3 newPostion = new(0f, -0.675f * i, 0f);
        return newPostion;
    }
}
