using Pathfinding.Ionic.Zip;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class V_TouchDialog : MonoBehaviour
{
    public GameObject DialScript;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player"))
            return;
        DialScript.gameObject.SetActive(true);
    }
}