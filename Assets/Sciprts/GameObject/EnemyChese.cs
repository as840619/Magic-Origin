using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChese : MonoBehaviour
{

    [Header("顏色對應距離")]
    [SerializeField] float blackOne = 1;
    [SerializeField] float grayThree = 3;
    [SerializeField] float whiteFive = 5;
    [SerializeField] float redSeven = 7;
    [SerializeField] float yellowNine = 9;
    [SerializeField] float greenSix = 11;
    public float speed;
    public float zombieNearFor = 8.5f;
    public float zombieNearBack = 3f;
    public float zombieStop = 1.5f;
    private string enemyType;
    //string enemyType => this.gameObject.GetComponent<ZombieNearShoot>().enemyType;

    private void Start()
    {
        ZombieNearShoot zombieNearShoot = GetComponentInChildren<ZombieNearShoot>();
        if (zombieNearShoot != null)
        {
            enemyType = zombieNearShoot.enemyType;
        }
    }

    private void Update()
    {
        float distanceFromPlayer = Vector2.Distance(playerPosition, transform.position);
        if (distanceFromPlayer < zombieStop)
            return;
        if (enemyType == "ZombieNear")
        {
            if (distanceFromPlayer < zombieNearFor && distanceFromPlayer > zombieNearBack)
                transform.position = Vector2.MoveTowards(this.transform.position, playerPosition, speed * Time.deltaTime);
            //if (distanceFromPlayer < zombieNearBack)
                //transform.position = Vector2.MoveTowards(this.transform.position, playerPosition, speed * Time.deltaTime);

        }
        if (enemyType == "ZombieFar")
            return;
    }

    Vector3 playerPosition => PlayerController.Instance.transform.position;

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
