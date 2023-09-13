using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Border : MonoBehaviour
{

    PlayerController _playerController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Debug.Log("00");
            //Freeze();
        }
    }

    IEnumerable Freeze()
    {
        Debug.Log("11");
        yield return new WaitForSeconds(2);
        Debug.Log("12");

    }
}
