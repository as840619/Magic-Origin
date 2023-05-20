using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGround
{
    GameObject player { get;}
    void Penetration(Vector2 playerPosition);
}
