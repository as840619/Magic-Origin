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
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }

    void TripperTake()      //3 to 1
    {
        for (int n = -1; n <= 1; n++)
        {
            Vector3 newPostion = Calculation(n);
            Instantiate(bullet, bulletPos.position + newPostion, Quaternion.identity);

        }
    }
    Vector3 Calculation(int i)
    {
        Vector3 newPostion = new Vector3(0f, -0.675f * i, 0f);
        return newPostion;
    }
}
