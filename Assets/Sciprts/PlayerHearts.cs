using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHearts : MonoBehaviour
{
    public List<GameObject> Hearts = new();
    

    public void POPOP()
    {
        Destroy(Hearts[3]);
    }
}
