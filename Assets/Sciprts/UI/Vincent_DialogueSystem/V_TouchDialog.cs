using Pathfinding.Ionic.Zip;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_TouchDialog : MonoBehaviour
{
    public GameObject DialScript;
    Rigidbody2D playerRb;
    //  public GameObject dialogueBox;
    private void OnTriggerEnter2D(Collider2D other)
    {
        playerRb = GameObject.FindWithTag("Player")?.GetComponent<Rigidbody2D>();
        if (GameObject.FindWithTag("Player"))
        {
            DialScript.gameObject.SetActive(true);
        }
        if (playerRb != null && DialScript != null)
        {
            DialScript.GetComponent<V_Dialog>().EndDialogue();
        }
    }

}
