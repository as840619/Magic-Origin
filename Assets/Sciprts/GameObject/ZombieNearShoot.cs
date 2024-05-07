using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieNearShoot : EnemyShooting
{
    [Header("攻擊距離")]
    [SerializeField] float lineOf11 = 9f;
    [SerializeField] float lineOf13 = 7f;
    public string enemyType = "ZombieNear";

    void Start()
    {
        anim = GetComponent<Animator>();
        player = PlayerController.Instance.gameObject;
    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, playerPosition);
        if (distance >= 12f)
            return;
        timer += Time.deltaTime;
        if (timer > gapFire)
        {
            timer = 0;
            anim.SetTrigger("Fire");
            if (distance >= lineOf13 && distance <= lineOf11)
            {
                Shoot();
                gapFire = 0.5f;
            }
            else if (distance >= 1.5f && distance <= lineOf13)
            {
                ShotgunShot();
                gapFire = 1f;
            }
        }
    }
}