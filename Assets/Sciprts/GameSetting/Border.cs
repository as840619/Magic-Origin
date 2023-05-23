using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{
    Collider2D _collider;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            Freeze();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
            Freeze();
    }


    IEnumerable Freeze()
    {
        Debug.Log("11");
        yield return new WaitForSeconds(2);
        Debug.Log("12");

    }
}
