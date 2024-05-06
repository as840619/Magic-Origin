using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.localScale = gameObject.transform.parent.localScale;
    }
}
