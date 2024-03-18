using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int shieldValue;

    private static PlayerManager instance;
    public static PlayerManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.Find("PlayerManager").GetComponent<PlayerManager>();
            return instance;
        }
    }
}
