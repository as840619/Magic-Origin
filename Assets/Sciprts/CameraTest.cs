using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    public float FlollowSpeed =2f;
    public float yoffset = 1f;
    public Transform target;

   void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y   +   yoffset,-10f);
        transform.position = Vector3.Slerp(transform.position,newPos,FlollowSpeed   *   Time.deltaTime);
    }
}
