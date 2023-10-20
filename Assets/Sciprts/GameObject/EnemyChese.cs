using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChese : MonoBehaviour
{
    public float speed;
    public float lineOfSite;

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(playerPosition, transform.position);
        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, playerPosition, speed * Time.deltaTime);
        }
    }

    Vector3 playerPosition => PlayerController.Instance.transform.position;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 7.5f);

    }
}
