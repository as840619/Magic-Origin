using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDrops : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CardManager.Instance.DropCard(transform.position);
            Destroy(gameObject);
        }
    }
}
