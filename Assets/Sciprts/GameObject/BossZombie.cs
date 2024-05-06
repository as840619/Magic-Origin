using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossZombie : MonoBehaviour
{
    [Header("子彈")]
    [SerializeField] GameObject bullet1;
    [SerializeField] GameObject bullet2;
    [SerializeField] GameObject bullet3;
    [SerializeField] Transform bulletPos;
    [Header("計時器")]
    [SerializeField] int op;
    [SerializeField] float gapFire = 4f;
    [SerializeField] float timer = 2f;
    [SerializeField] float opTimer;
    [SerializeField] float temp = 2f;
    [Header("距離判定")]
    public float speed = 0.1f;
    public float zombieNearFor = 8.5f;
    public float zombieNearBack = 3f;
    public float zombieStop = 1.5f;
    [Header("顏色對應距離")]
    [SerializeField] float blackOne = 1;
    [SerializeField] float grayThree = 3;
    [SerializeField] float whiteFive = 5;
    [SerializeField] float redSeven = 7;
    [SerializeField] float yellowNine = 9;
    [SerializeField] float greenSix = 11;
    private GameObject player;
    private PlayerHealth playerHealth;
    private Animator anim;

    private string enemyType;

    private void Start()
    {
        //First();
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
        //player = PlayerController.Instance.gameObject;
    }

    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(playerPosition, transform.position);
        if (distanceFromPlayer < zombieStop)
            return;
        if (PlayerController.Instance.bossBattle == false)
            return;
        timer += Time.deltaTime;
        if (timer > gapFire)
        {
            timer = 0;
            int mode = Random.Range(0, 8);
            //anim.SetTrigger("Fire");
            //Raining();
            switch (mode)
            {
                case 0:
                    int n = 1;
                    for (int i = 0; i <= 36; i++)
                        Shoot(i, n);
                    gapFire = 0.5f;
                    n += 5;
                    break;
                case 1:
                    ShotgunShot();
                    gapFire = 0.5f;
                    break;
                /*case 2:
                    Pentagram();
                    gapFire = 0.25f;
                    break;
                case 3:
                    WrongFuckingShoot();
                    gapFire = 0.125f;
                    break;*/
                case 2:
                    LerpShot();
                    gapFire = 1f;
                    break;
                case 3:
                    TripperTake();
                    gapFire = 0.75f;
                    break;

            }
        }
        //隨機
        /*opTimer += Time.deltaTime;
        if (opTimer > temp)
        {
            opTimer = 0;
            op = (op + 1) % 6;
        }*/
    }

    public Vector3 playerPosition => PlayerController.Instance.Position;
    public Vector2 playerDirection => playerPosition - transform.position;
    public float playerAngle => Mathf.Atan2(playerDirection.y, playerDirection.x) * Mathf.Rad2Deg;
    public GameObject AngleFix(float angle)
    {
        GameObject bulletFive = Instantiate(bullet1, bulletPos.position, Quaternion.identity);
        Vector2 angleWay = new Vector2(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)).normalized;
        bulletFive.GetComponent<EnemybulletScript>().way = angleWay;
        return bulletFive;
    }

    public void Shoot(int i, int n)        //1 to 1
    {
        AngleFix(playerAngle + i * (10 + n));
        GameManager.Instance.audioManager.Play(4, "seEnemyShoot", false);
    }

    public void ShotgunShot()  //1 to 3
    {
        for (int i = -1; i <= 1; i++)
        {
            GameObject bulletSS = AngleFix(playerAngle + i * 2.5f);
            bulletSS.GetComponent<EnemybulletScript>().reCallTime = 3F;
        }
        GameManager.Instance.audioManager.Play(4, "seEnemyShoot", false);
    }

    public void Pentagram()    //0 to 5
    {
        float angleAim = playerAngle;
        for (int m = 0; m <= 5; m++)
        {
            GameObject bulletFive = AngleFix(angleAim);
            angleAim += 72;
        }
        GameManager.Instance.audioManager.Play(4, "seEnemyShoot", false);
    }

    public void WrongFuckingShoot()    //0 to 5
    {
        GameObject bulletShit = AngleFix(Mathf.Atan2(playerDirection.x, playerDirection.y) * Mathf.Rad2Deg);
        GameManager.Instance.audioManager.Play(4, "seEnemyShoot", false);
    }

    public void LerpShot()     //lerp 1 to 1
    {
        GameObject bulletLerp = Instantiate(bullet2, bulletPos.position, Quaternion.identity);
        bulletLerp.GetComponent<EnemybulletScript>().way = playerDirection;
        bulletLerp.GetComponent<EnemybulletScript>().lerping = true;
        GameManager.Instance.audioManager.Play(4, "seEnemyShoot", false);
    }
    //捲捲面
    public Vector2 Calculation(int i)
    {
        GameManager.Instance.audioManager.Play(4, "seEnemyShoot", false);
        Vector2 newPosition = new(0f, -0.675f * i);
        return newPosition;
        
    }

    public void TripperTake()      //3 to 1
    {
        for (int n = -1; n <= 1; n++)
        {
            Vector3 newPosition = Calculation(n);
            GameObject bulletTTO = Instantiate(bullet3, bulletPos.position + newPosition, Quaternion.identity);
            Vector2 direction = playerPosition - bulletTTO.transform.position;
            bulletTTO.GetComponent<EnemybulletScript>().way = direction;
        }
        GameManager.Instance.audioManager.Play(4, "seEnemyShoot", false);
    }

    public void Raining()      //  _|_
    {
        float middlePoint = (playerPosition.x + bulletPos.transform.position.x) / 2;
        GameObject bulletRain = Instantiate(bullet1, new(middlePoint, (2 * bulletPos.position.y)), Quaternion.identity);
        //bulletRain.GetComponent<EnemybulletScript>().way = -(transform.up);
        bulletRain.GetComponent<EnemybulletScript>().splits = 2;
        GameManager.Instance.audioManager.Play(4, "seEnemyShoot", false);
    }

    private void First()
    {
        transform.position = Vector2.left * speed * 0.5F;
        //transform.position = Vector2.MoveTowards(this.transform.position, playerPosition, speed * 2F);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(transform.position, blackOne);
        Gizmos.color = Color.gray;
        Gizmos.DrawWireSphere(transform.position, grayThree);
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, whiteFive);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, redSeven);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, yellowNine);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, greenSix);
    }
}