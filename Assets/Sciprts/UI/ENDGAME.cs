using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENDGAME : MonoBehaviour
{
    public GameObject Endthis;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Endthis.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Debug.Log("QUITGAME");
        Application.Quit();
    }
}
