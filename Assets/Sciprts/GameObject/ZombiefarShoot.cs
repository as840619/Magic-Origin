using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiefarShoot : EnemyShooting
{
    [Header("攻擊距離")]
    [SerializeField] float lineOflerp = 12f;
    [SerializeField] float lineOf31 = 5f;
    [SerializeField] float lineOf13 = 1.5f;
    public string enemyType = "ZombieFar";

    void Start()
    {
        anim = GetComponent<Animator>();
        player = PlayerController.Instance.gameObject;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, playerPosition);
        if (distance >= lineOflerp)
            return;
        timer += Time.deltaTime;
        if (timer > gapFire)
        {
            timer = 0;
            anim.SetTrigger("Fire");
            if (distance >= lineOf31 && distance <= lineOflerp)
            {
                LerpShot();
                gapFire = 1f;
            }
            else if (distance >= lineOf13 && distance <= lineOf31)
            {
                switch (op)
                {
                    case 0:
                        TripperTake();
                        gapFire = 0.5f;
                        break;
                    case 1:
                        ShotgunShot();
                        gapFire = 0.5f;
                        break;
                }
            }
            opTimer += Time.deltaTime;
            if (opTimer > temp)
            {
                opTimer = 0;
                op = (op + 1) % 2;
            }
        }
    }
}